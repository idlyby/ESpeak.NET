
namespace ESpeakNET.Interop;

[System.Flags]
public enum ESpeakStatus : int
{
    InternalError = -1,
    Ok = 0,
    BufferFull = 1,
    NotFound = 2
}