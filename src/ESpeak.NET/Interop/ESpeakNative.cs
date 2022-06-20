
using System;
using System.Runtime.InteropServices;

namespace ESpeakNET.Interop;

internal static unsafe partial class ESpeakNative
{
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl)]
    public static extern ESpeakStatus espeak_Cancel();
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    public static extern ESpeakStatus espeak_Char(char c);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern void espeak_CompileDictionary([MarshalAs(UnmanagedType.LPStr)]string path, IntPtr log, int flags);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl)]
    public static extern ESpeakVoice* espeak_GetCurrentVoice();
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl)]
    public static extern int espeak_GetParameter(ESpeakParameter parameter, int current);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern ESpeakStatus espeak_Key([MarshalAs(UnmanagedType.LPStr)]string k);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern byte* espeak_Info(byte** pathData);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern int espeak_Initialize(ESpeakAudioOutput output, int bufferLength, [MarshalAs(UnmanagedType.LPStr)]string? path, int options);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl)]
    public static extern int espeak_IsPlaying();
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl)]
    public static extern ESpeakVoice** espeak_ListVoices(ESpeakVoice* voiceSpec);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl)]
    public static extern void espeak_SetSynthCallback([MarshalAs(UnmanagedType.FunctionPtr)]ESpeakSynthCallback callback);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl)]
    public static extern ESpeakStatus espeak_SetParameter(ESpeakParameter parameter, int value, int relative);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
    public static extern ESpeakStatus espeak_SetPunctuationList(string punctList);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern ESpeakStatus espeak_SetVoiceByFile([MarshalAs(UnmanagedType.LPStr)]string filename);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern ESpeakStatus espeak_SetVoiceByName([MarshalAs(UnmanagedType.LPStr)]string name);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl)]
    public static extern ESpeakStatus espeak_SetVoiceByProperties(ESpeakVoice* voiceSpec);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl)]
    public static extern ESpeakStatus espeak_Synchronize();
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern ESpeakStatus espeak_Synth([MarshalAs(UnmanagedType.LPStr)]string text, uint textLength, uint position, ESpeakPositionType positionType, uint endPosition, uint flags, UIntPtr uniqueIdentifier, IntPtr userData);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern ESpeakStatus espeak_Synth_Mark([MarshalAs(UnmanagedType.LPStr)]string text, uint textLength, [MarshalAs(UnmanagedType.LPStr)]string indexMark, uint endPosition, uint flags, UIntPtr uniqueIdentifier, IntPtr userData);
    [DllImport("libespeak-ng", CallingConvention = CallingConvention.Cdecl)]
    public static extern ESpeakStatus espeak_Terminate();
}