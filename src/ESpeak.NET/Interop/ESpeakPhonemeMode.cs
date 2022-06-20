
namespace ESpeakNET.Interop;

[System.Flags]
public enum ESpeakPhonemeMode : int
{
    Show = 0x01,
    IPA = 0x02,
    Trace = 0x08,
    Mbrola = 0x10,
    Tie = 0x80
}
