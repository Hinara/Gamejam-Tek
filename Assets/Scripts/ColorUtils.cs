using UnityEngine;

public class ColorUtils : IColorUtils
{
    public Color getColor(float value)
    {
        if (value < 0.0f || value > 1.0f)
        {
            return Color.black;
        }
        value *= 6.0f;
        if (value <= 1.0f)
        {
            return new Color(1.0f, value, 0);
        }
        else if (value <= 2.0f)
        {
            return new Color(1.0f - (value - 1.0f), 1.0f, 0);
        }
        else if (value <= 3.0f)
        {
            return new Color(0, 1.0f, (value - 2.0f));
        }
        else if (value <= 4.0f)
        {
            return new Color(0, 1.0f - (value - 3.0f), 1.0f);
        }
        else if (value <= 5.0f)
        {
            return new Color((value - 4.0f), 0, 1.0f);
        }
        return new Color(1.0f, 0, 1.0f - (value - 5.0f));
    }
}
