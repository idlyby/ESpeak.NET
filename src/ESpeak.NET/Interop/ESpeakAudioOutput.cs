
namespace ESpeakNET.Interop;

[System.Flags]
public enum ESpeakAudioOutput : int
{
    Playback,
    Retrieval,
    Synchronous,
    SynchronousPlayback
}