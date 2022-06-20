
using System.Runtime.InteropServices;

namespace ESpeakNET.Interop;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct ESpeakEventId
{
    [FieldOffset(0)]
    public int Number;
    [FieldOffset(0)]
    public byte* Name;
    [FieldOffset(0)]
    public fixed byte String[8];
}