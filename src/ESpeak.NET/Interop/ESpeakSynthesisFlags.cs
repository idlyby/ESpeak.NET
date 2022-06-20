
namespace ESpeakNET.Interop;

[System.Flags]
public enum ESpeakSynthesisFlags : uint
{
    CharsAuto = 0u,
    CharsUTF8 = 1u,
    Chars8bit = 2u,
    CharsWChar = 3u,
    Chars16bit = 4u,
    SSML = 0x10u,
    Phonemes = 0x100u,
    EndPause = 0x1000u,
    KeepNameData = 0x2000u
}