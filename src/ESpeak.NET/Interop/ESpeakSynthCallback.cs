
namespace ESpeakNET.Interop;

public unsafe delegate int ESpeakSynthCallback(short* wav, int numsamples, ESpeakEvent* events);