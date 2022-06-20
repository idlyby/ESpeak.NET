using System;
using System.Collections.Generic;

using ESpeakNET.Interop;

namespace ESpeakNET;

public unsafe partial class ESpeak
{
    /// <summary>
    /// Compile pronunciations for a language using currently selected voice.
    /// </summary>
    /// <param name="path">Directory containing the language definitions.</param>
    public void CompileDictionary(string path)
        => ESpeakNative.espeak_CompileDictionary(path, IntPtr.Zero, 0);

    /// <summary>
    /// Retrieve currently selected voice.
    /// </summary>
    /// <returns>Pointer to currently selected voice.</returns>
    public ESpeakVoicePtr GetCurrentVoice()
    {
        var ptr = ESpeakNative.espeak_GetCurrentVoice();
        return new ESpeakVoicePtr(ptr);
    }

    public const int VoiceArrayMaximumItems = 350;
    private void WrapVoices(ESpeakVoice** nativePtrs, out List<ESpeakVoicePtr> wrappedPtrs)
    {
        wrappedPtrs = new List<ESpeakVoicePtr>();
        for (int i = 0; i < VoiceArrayMaximumItems; i++)
        {
            var ptr = nativePtrs[i];
            if (ptr == (ESpeakVoice*)0)
            {
                break;
            }
            wrappedPtrs.Add(new ESpeakVoicePtr(ptr));
        }
    }

    /// <summary>
    /// Retrieves a list of available voices in the data path.
    /// </summary>
    /// <returns>Pointer-to-pointer array of voices.</returns>
    public List<ESpeakVoicePtr> ListVoices()
    {
        List<ESpeakVoicePtr> wrappedPtrs;
        var nativePtrs = ESpeakNative.espeak_ListVoices((ESpeakVoice*)IntPtr.Zero);
        WrapVoices(nativePtrs, out wrappedPtrs);
        return wrappedPtrs;
    }
    /// <summary>
    /// Retrieves a list of available voices matching the voice specification.
    /// </summary>
    /// <param name="voiceSpec">A voice relating to desired voice criteria.</param>
    /// <returns>Pointer-to-pointer array of voices matching the critera. </returns>
    public List<ESpeakVoicePtr> ListVoices(ESpeakVoicePtr voiceSpec)
    {
        List<ESpeakVoicePtr> wrappedPtrs;
        var nativePtrs = ESpeakNative.espeak_ListVoices(voiceSpec.NativePtr);
        WrapVoices(nativePtrs, out wrappedPtrs);
        return wrappedPtrs;
    }


    /// <summary>
    /// Loads a voice using the given file path.
    /// </summary>
    /// <param name="filename">Path to the voice. </param>
    public bool SetVoiceByFile(string filename)
        => ESpeakNative.espeak_SetVoiceByFile(filename) == ESpeakStatus.Ok;

    /// <summary>
    /// Loads a voice using an identifier.
    /// </summary>
    /// <param name="name">The voice identifier.</param>
    public bool SetVoiceByName(string name)
        => ESpeakNative.espeak_SetVoiceByName(name) == ESpeakStatus.Ok;

    /// <summary>
    /// Loads a voice using a voice as comparison.
    /// </summary>
    /// <param name="voiceSpec">The voice for selecting criteria.</param>
    public bool SetVoiceByProperties(ESpeakVoicePtr voiceSpec)
    {
        var status = ESpeakNative.espeak_SetVoiceByProperties(voiceSpec.NativePtr);
        return status == ESpeakStatus.Ok;
    }

    /// <summary>
    /// TODO
    /// </summary>
    public bool SetPunctuationList(string punctList)
        => ESpeakNative.espeak_SetPunctuationList(punctList) == ESpeakStatus.Ok;
}