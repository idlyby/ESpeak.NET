
using System;

using ESpeakNET.Interop;

namespace ESpeakNET;

public unsafe partial class ESpeak
{
    private bool ForceSynchronousPlayback(ESpeakStatus status)
    {
        var sync = ESpeakNative.espeak_Synchronize();
        return status == ESpeakStatus.Ok && sync == ESpeakStatus.Ok;
    }
    /// <summary>
    /// Produce and/or play a single UNICODE character.
    /// </summary>
    /// <param name="keyName">The unicode character to be spoken or produced.</param>
    public bool SynthCharacter(char c)
    {
        var status = ESpeakNative.espeak_Char(c);
        return ForceSynchronousPlayback(status);
    }

    /// <summary>
    /// Produce and/or play a single ANSI keyboard character.
    /// </summary>
    /// <param name="keyName">The ANSI character to be spoken or produced.</param>
    public bool SynthKeyName(string keyName)
    {
        var status = ESpeakNative.espeak_Key(keyName);
        return ForceSynchronousPlayback(status);
    }
    /// <summary>
    /// Produce and/or play a string of text.
    /// </summary>
    /// <param name="text">The sentence/s to be spoken or produced.</param>
    public bool SynthText(string text)
    {
        var status = ESpeakNative.espeak_Synth(text, (uint)text.Length, 0u, ESpeakPositionType.None, 0u, (UInt32)ESpeakSynthesisFlags.CharsAuto, UIntPtr.Zero, IntPtr.Zero);
        return ForceSynchronousPlayback(status);
    }
    /// <summary>
    /// Check if eSpeak is currently playing.
    /// </summary>
    public bool IsPlaying()
        => ESpeakNative.espeak_IsPlaying() == 1;

    /// <summary>
    /// TODO
    /// </summary>
    public void SetSynthCallback(ESpeakSynthCallback callback)
        => ESpeakNative.espeak_SetSynthCallback(callback);

}