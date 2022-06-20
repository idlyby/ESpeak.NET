
using System;
using System.Runtime.CompilerServices;

namespace ESpeakNET.Interop;

public unsafe struct ESpeakVoice
{
    public byte* Name;
    public byte* Languages;
    public byte* Identifier;
    public byte Gender;
    public byte Age;
    public byte Variant;
#pragma warning disable CS0169 // Field/s that are used internally.
    private byte XX1;
    private int Score;
    private byte* Spare;
#pragma warning restore CS0169
}

public unsafe struct ESpeakVoicePtr
{
    public ESpeakVoice* NativePtr { get; }
    public ESpeakVoicePtr(ESpeakVoice* nativePtr) => NativePtr = nativePtr;
    public ESpeakVoicePtr(IntPtr nativePtr) => NativePtr = (ESpeakVoice*)nativePtr;
    public static implicit operator ESpeakVoicePtr(ESpeakVoice* nativePtr) => new ESpeakVoicePtr(nativePtr);
    public static implicit operator ESpeakVoice* (ESpeakVoicePtr wrappedPtr) => wrappedPtr.NativePtr;
    public static implicit operator ESpeakVoicePtr(IntPtr nativePtr) => new ESpeakVoicePtr(nativePtr);
    public ByteString Name => new ByteString(NativePtr->Name);
    public ByteString Languages => new ByteString(NativePtr->Languages);
    public ByteString Identifier => new ByteString(NativePtr->Identifier);
    public ref uint Gender => ref Unsafe.AsRef<uint>(&NativePtr->Gender);
    public ref uint Age => ref Unsafe.AsRef<uint>(&NativePtr->Age);
    public ref uint Variant => ref Unsafe.AsRef<uint>(&NativePtr->Variant);
}