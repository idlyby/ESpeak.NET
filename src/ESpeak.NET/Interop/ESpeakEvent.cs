
using System;
using System.Runtime.CompilerServices;

namespace ESpeakNET.Interop;

public unsafe struct ESpeakEvent
{
    public ESpeakEventType Type;
    public uint UniqueIdentifier;
    public int TextPosition;
    public int Length;
    public int AudioPosition;
#pragma warning disable CS0169 // Sample used internally
    private int Sample;
#pragma warning restore CS0169
    public byte* UserData;
    public ESpeakEventId Id;
}

public unsafe struct ESpeakEventPtr
{
    public ESpeakEvent* NativePtr { get; }
    public ESpeakEventPtr(ESpeakEvent* nativePtr) => NativePtr = nativePtr;
    public ESpeakEventPtr(IntPtr nativePtr) => NativePtr = (ESpeakEvent*)nativePtr;
    public static implicit operator ESpeakEventPtr(ESpeakEvent* nativePtr) => new ESpeakEventPtr(nativePtr);
    public static implicit operator ESpeakEvent* (ESpeakEventPtr wrappedPtr) => wrappedPtr.NativePtr;
    public static implicit operator ESpeakEventPtr(IntPtr nativePtr) => new ESpeakEventPtr(nativePtr);
    public ref ESpeakEventType Type => ref Unsafe.AsRef<ESpeakEventType>(&NativePtr->Type);
    public ref uint UniqueIdentifier => ref Unsafe.AsRef<uint>(&NativePtr->UniqueIdentifier);
    public ref int TextPosition => ref Unsafe.AsRef<int>(&NativePtr->TextPosition);
    public ref int Length => ref Unsafe.AsRef<int>(&NativePtr->Length);
    public ref int AudioPosition => ref Unsafe.AsRef<int>(&NativePtr->AudioPosition);
    public ref ESpeakEventId Id => ref Unsafe.AsRef<ESpeakEventId>(&NativePtr->Id);
}