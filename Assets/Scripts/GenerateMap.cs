using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class GenerateMap : MonoBehaviour
{
    [SerializeField]
    TextAsset map;
    [SerializeField]
    float moveSpeed = 1e4f;
    [SerializeField]
    GameObject pointModel;
    bool start = false;

    private void Start()
    {
        bool success = true;
        string[] lines = map.text.Split('\n');

        for (int i = 0; i < lines.Length; i++) {
            lines[i] = lines[i].TrimEnd('\r');
        }
        print("Slimerunner".Length);
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
    }
    private void Update()
    {
        if (start == false)
        {
            gameObject.GetComponent<AudioSource>().Play();
            start = true;
        }
    }

    private bool parseLine(string line)
    {
        string[] arr = line.Split(' ');
        if (arr.Length >= 1)
        {
            switch(arr[0])
            {
                case "Point":
                    return generatePoint(arr);
                case "Slider":
                    return generateSlider(arr);
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

            float start = float.Parse(args[1], CultureInfo.InvariantCulture) / 1000.0f;
            GameObject go = Instantiate(pointModel, transform);
            go.transform.localPosition += Vector3.right * start * moveSpeed;
            go.GetComponent<Point>().speed = moveSpeed;
        }
        catch
        {
            return false;
        }
        return true;
    }

    private bool generateSlider(string[] args)
    {
        if (args.Length != 3)
        {
            return false;
        }
        try
        {

            float start = float.Parse(args[1], CultureInfo.InvariantCulture);
            float end = float.Parse(args[2], CultureInfo.InvariantCulture);

        }
        catch
        {
            return false;
        }
        return false;
    }
}
