
using ESpeakNET;

unsafe
{
    using var speaker = new ESpeak();
    Console.WriteLine($"Initialized: {speaker.NativeVersion} {speaker.DataPath}");
    speaker.SynthCharacter('A');
    speaker.SynthKeyName("B C D");
    speaker.SynthText("EFGHIJKLMNOPQRSTUVWXYZ");

    var current = speaker.GetCurrentVoice();
    Console.WriteLine($"Current Voice: {current.Identifier}");
    
    var voices = speaker.ListVoices();

    foreach (var voice in voices)
    {
        Console.WriteLine($"Selectable Voice: {voice.Identifier}");
    }
}
