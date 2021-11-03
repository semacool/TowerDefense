/// <summary>
/// вспомагательный класс
/// </summary>
public class Util
{
    public static string ChangeText(string source, object newValue)
    {
        var text = source.Split(':')[0] + ": " + newValue.ToString();
        return text;
    }

    public static float Round(float value)
    {
        var changeValue = value;
        changeValue = ((int)(changeValue * 100)) / 100f;
        return changeValue;
    }
}
