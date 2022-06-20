
namespace ESpeakNET.Interop;

[System.Flags]
public enum ESpeakEventType : int
{
    ListTerminated = 0,
    Word,
    Sentence,
    Mark,
    Play,
    End,
    MessageTerminated,
    Phoneme,
    SampleRate
}