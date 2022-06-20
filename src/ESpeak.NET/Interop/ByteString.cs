
using System.Text;

namespace ESpeakNET.Interop;

public unsafe struct ByteString
{
    public readonly byte* Text;

    public ByteString(byte* text) => Text = text;
    public static implicit operator string (ByteString byteStr) => byteStr.ToString();
    public override string ToString()
    {
        int bytes = 0;
        byte* ptr = Text;
        while (ptr[bytes] != 0)
        {
            bytes++;
        }
        if (bytes == 0)
        {
            return string.Empty;
        }
        return Encoding.ASCII.GetString(Text, bytes);
    }
}