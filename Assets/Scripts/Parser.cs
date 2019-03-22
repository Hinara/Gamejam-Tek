using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;


public class Parser
{
    Game game;
    public Parser(Game game)
    {
        this.game = game;
    }

    public bool Parse(string text)
    {
        bool success = true;
        string[] lines = text.Split('\n');

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = lines[i].TrimEnd('\r');
        }
        if (lines.Length >= 1 && lines[0] == "Slimerunner")
        {
            for (int i = 1; i < lines.Length; i++)
            {
                bool res = parseLine(lines[i]);
                if (res == false)
                {
                    Debug.LogWarning("Line " + i + " is invalid:" + lines[i]);
                }
                success = success && res;
            }
        }
        return success;
    }
    private bool parseLine(string line)
    {
        string[] arr = line.Split(' ');
        if (arr.Length >= 1)
        {
            switch (arr[0])
            {
                case "Point":
                    return generatePoint(arr);
                case "Stream":
                    return generateSlider(arr);
                case "":
                    return arr.Length == 1;
            }
        }
        return false;
    }
    private bool generatePoint(string[] args)
    {
        if (args.Length != 2)
        {
            return false;
        }
        try
        {
            float value = float.Parse(args[1], CultureInfo.InvariantCulture) / 1000.0f;
            game.addPoint(value);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private bool generateSlider(string[] args)
    {
        if (args.Length != 3)
        {
            Debug.Log(args.Length);
            return false;
        }
        try
        {
            float start = float.Parse(args[1], CultureInfo.InvariantCulture) / 1000.0f;
            float end = float.Parse(args[2], CultureInfo.InvariantCulture) / 1000.0f;
            game.addStream(start, end);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
