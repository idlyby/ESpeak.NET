using Xunit;

namespace ESpeakNET;

public unsafe partial class ESpeak_Tests
{
    [Fact]
    public void Construct_SampleRatePositiveValue()
    {
        using var speaker = new ESpeak();
        Assert.True((speaker.SampleRate > -1), "SampleRate should return integer larger than -1.");
    }

    [Fact]
    public void Construct_CannotConstructMoreThanOnce()
    {
        bool caught = false;
        using var speaker = new ESpeak();
        try
        {
            using var speaker2 = new ESpeak();
        }
        catch
        {
            caught = true;
        }
        Assert.True(caught, "ESpeak can only be used as a singleton-like instance.");
    }
    [Fact]
    public void Construct_CanConstructAfterDisposingOld()
    {
        bool caught = false;
        using var speaker = new ESpeak();
        speaker.Dispose();
        try
        {
            using var newSpeaker = new ESpeak();
        }
        catch
        {
            caught = true;
        }
        Assert.False(caught, "ESpeak can be constructed again if the current instance is disposed.");
    }
    [Fact]
    public void NativeVersion_Initialized()
    {
        using var speaker = new ESpeak();
        bool notNullOrEmpty = !string.IsNullOrEmpty(speaker.NativeVersion);
        Assert.True(notNullOrEmpty, "Native Version should be set to a non empty string.");
    }

    [Fact]
    public void Char_ReturnsTrue()
    {
        using var speaker = new ESpeak();
        bool spoken = speaker.SynthCharacter('A');
        Assert.True(spoken, "SynthCharacter should return true.");
    }
    [Fact]
    public void Key_ReturnsTrue()
    {
        using var speaker = new ESpeak();
        bool spoken = speaker.SynthKeyName("A");
        Assert.True(spoken, "Key should return true.");
    }
    [Fact]
    public void Synth_ReturnsTrue()
    {
        using var speaker = new ESpeak();
        bool synthesized = speaker.SynthText("hello");
        Assert.True(synthesized, "Synthesize should return true.");
    }

    [Fact]
    public void CurrentVoice_ReturnsVoicePtr()
    {
        using var speaker = new ESpeak();
        var voice = speaker.GetCurrentVoice();
        string identifier = voice.Name;
        bool equals = string.Compare(identifier, @"gmw\en") == 0;
        Assert.True(equals, @"Initial voice is set as gmw\en");
    }
}