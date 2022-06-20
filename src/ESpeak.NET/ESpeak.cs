
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

using ESpeakNET.Interop;

namespace ESpeakNET;

public unsafe partial class ESpeak : IDisposable
{
    private static int _instanced;
    public const int SoundBufferMinimumLength = 60; // ms

    public readonly ESpeakAudioOutput AudioOutput;
    public readonly int BufferLength;
    public readonly string? DataPath;
    public readonly string? NativeVersion;
    public readonly int SampleRate = -1;
    public ESpeak(
        ESpeakAudioOutput audioOutput = ESpeakAudioOutput.SynchronousPlayback,
        int bufferLength = SoundBufferMinimumLength,
        string dataPath = "")
    {
        if (Interlocked.Increment(ref _instanced) > 1)
        {
            throw new InvalidOperationException("Only one ESpeak object may be initialized at any one time.");
        }

        AudioOutput = audioOutput;
        BufferLength = bufferLength;

        if (!string.IsNullOrEmpty(dataPath) 
            && Directory.Exists(dataPath))
        {
            DataPath = dataPath;
        }
        else
        {
            string? runtimePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!string.IsNullOrEmpty(runtimePath)
                && Directory.Exists(runtimePath))
            {
                char separator = Path.DirectorySeparatorChar;
                DataPath = $"{runtimePath}{separator}espeak-ng-data";
            }
        }

        SampleRate = ESpeakNative.espeak_Initialize(AudioOutput, BufferLength, DataPath, 0);

        if (SampleRate == -1)
        {
            throw new ExternalException("Unable to initialize espeak.");
        }

        byte* infoPtr;
        byte* versionPtr = ESpeakNative.espeak_Info(&infoPtr);
        
        ByteString info = new ByteString(infoPtr);
        ByteString version = new ByteString(versionPtr);
        
        DataPath ??= info;
        NativeVersion ??= version;
    }

    /// <summary>
    /// Stops currently playing
    /// </summary>
    public void Cancel()
        => ESpeakNative.espeak_Cancel();

    /// <summary>
    /// Synchronize main thread with eSpeak internal thread.
    /// </summary>
    public void Synchronize()
        => ESpeakNative.espeak_Synchronize();

    public void Dispose()
    {
        Interlocked.Exchange(ref _instanced, 0);
        var status = ESpeakNative.espeak_Terminate();
        if (status != ESpeakStatus.Ok)
        {
            throw new ExternalException("Unable to terminate ESpeak process.");
        }
    }
}