using UnityEngine;

public class Colorz
{
    // Class full of support functions for the game's
    // Color functionality.
    public static string GetOppositeColorStr(bool r, bool g, bool b)
    {
        string opCol = "";
        if (!r)
        {
            opCol += "R";
        }

        if (!g)
        {
            opCol += "G";
        }

        if (!b)
        {
            opCol += "B";
        }
        return opCol;
    }

    public static string GetColorStr(Color color)
    {
        bool r = false;
        bool g = false;
        bool b = false;

        if (color.r >= 1)
        {
            r = true;
        }

        if (color.g >= 1)
        {
            g = true;
        }

        if (color.b >= 1)
        {
            b = true;
        }

        return GetColorStr(r, g, b);
    }

    public static string GetColorStr(bool r, bool g, bool b)
    {
        string colStr = "";
        if (r)
        {
            colStr += "R";
        }

        if (g)
        {
            colStr += "G";
        }

        if (b)
        {
            colStr += "B";
        }
        return colStr;
    }

    public static Color GetColor(bool r, bool g, bool b)
    {
        float Rval = 0;
        float Gval = 0;
        float Bval = 0;
        
        if (r)
        {
            Rval = 1;
        }

        if (g)
        {
            Gval = 1;
        }

        if (b)
        {
            Bval = 1;
        }

        return new Color(Rval, Gval, Bval);
    }
}