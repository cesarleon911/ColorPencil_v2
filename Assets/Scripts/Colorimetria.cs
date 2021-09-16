using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorimetria
{
    private int HexToDec(string hex)
    {
        int dec = System.Convert.ToInt32(hex, 16);
        return dec;
    }

    private string DecToHex(int value)
    {
        return value.ToString("X2");
    }

    private string FloatNormalizeToHex(float value)
    {
        return DecToHex(Mathf.RoundToInt(value * 255f));
    }

    private float HexToFloatNormalized(string hex)
    {
        return HexToDec(hex) / 255f;
    }

    public Color GetColorFromString(string hexString)
    {
        float rojo = HexToFloatNormalized(hexString.Substring(0, 2));
        float verde = HexToFloatNormalized(hexString.Substring(2, 2));
        float azul = HexToFloatNormalized(hexString.Substring(4, 2));
        float alfa = HexToFloatNormalized(hexString.Substring(6, 2));

        return new Color(rojo, verde, azul, alfa);
    }

    public string getStringfromColor(Color color)
    {
        string rojo = FloatNormalizeToHex(color.r);
        string verde = FloatNormalizeToHex(color.g);
        string azul = FloatNormalizeToHex(color.b);
        string alfa = FloatNormalizeToHex(color.a);

        return rojo + verde + azul + alfa;
    }
}
