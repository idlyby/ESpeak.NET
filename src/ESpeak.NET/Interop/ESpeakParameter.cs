
namespace ESpeakNET.Interop;

[System.Flags]
internal enum ESpeakParameter : uint
{
    Silence = 0,
    Rate,
    Volume,
    Pitch,
    Range,
    Punctuation,
    Capitals,
    WordGap,
    Options,
    Intonation,
    Reserved1,
    Reserved2,
    Emphasis,
    LineLength,
    VoiceType,
    SpeechParam
}

