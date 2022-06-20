
using ESpeakNET.Interop;

namespace ESpeakNET;

public unsafe partial class ESpeak
{
    /// <summary>
    /// Retrieve currently set value for a parameter.
    /// </summary>
    /// <param name="parameter">The parameter to retrieve.</param>
    /// <returns>The requested parameter value.</returns>
    private int GetParameter(ESpeakParameter parameter)
        => ESpeakNative.espeak_GetParameter(parameter, 1);

    /// <summary>
    /// Retrieve the default value for a parameter.
    /// </summary>
    /// <param name="parameter">The parameter to retrieve.</param>
    /// <returns>The requested default parameter value.</returns>
    private int GetParameterDefault(ESpeakParameter parameter)
        => ESpeakNative.espeak_GetParameter(parameter, 0);

    /// <summary>
    /// Set the selected parameter to absolute value. Handled by ESpeak.
    /// </summary>
    /// <param name="parameter">The parameter to change.</param>
    /// <param name="value">The number to set the parameter to.</param>
    private bool SetParameter(ESpeakParameter parameter, int value)
        => ESpeakNative.espeak_SetParameter(parameter, value, 0) == ESpeakStatus.Ok;
    
    /// <summary>
    /// Set the selected parameter relative to value. Handled by ESpeak.
    /// </summary>
    /// <param name="parameter">The parameter to change.</param>
    /// <param name="value">The number to set the parameter to.</param>
    private bool SetParameterRelative(ESpeakParameter parameter, int value)
        => ESpeakNative.espeak_SetParameter(parameter, value, 1) == ESpeakStatus.Ok;

    public int Rate
    {
        get => GetParameter(ESpeakParameter.Rate);
        set => SetParameter(ESpeakParameter.Rate, value);
    }
    public int RateRelative(int value)
    {
        SetParameterRelative(ESpeakParameter.Rate, value);
        return Rate;
    }
    public int Volume
    {
        get => GetParameter(ESpeakParameter.Volume);
        set => SetParameter(ESpeakParameter.Volume, value);
    }
    public int VolumeRelative(int value)
    {
        SetParameterRelative(ESpeakParameter.Volume, value);
        return Volume;
    }
    public int Pitch
    {
        get => GetParameter(ESpeakParameter.Pitch);
        set => SetParameter(ESpeakParameter.Pitch, value);
    }
    public int PitchRelative(int value)
    {
        SetParameterRelative(ESpeakParameter.Pitch, value);
        return Pitch;
    }
    public int Range
    {
        get => GetParameter(ESpeakParameter.Range);
        set => SetParameter(ESpeakParameter.Range, value);
    }
    public int RangeRelative(int value)
    {
        SetParameterRelative(ESpeakParameter.Range, value);
        return Range;
    }
    public int Punctuation
    {
        get => GetParameter(ESpeakParameter.Punctuation);
        set => SetParameter(ESpeakParameter.Punctuation, value);
    }
    public int Capitals
    {
        get => GetParameter(ESpeakParameter.Capitals);
        set => SetParameter(ESpeakParameter.Capitals, value);
    }
    public int WordGap
    {
        get => GetParameter(ESpeakParameter.WordGap);
        set => SetParameter(ESpeakParameter.WordGap, value);
    }
}