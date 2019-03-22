using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    TextAsset map;
    [SerializeField]
    float moveSpeed = 1e4f;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject pointModel;
    [SerializeField]
    Lives lives;
    [SerializeField]
    ColorPicker picker;

    uint score = 0;
    bool start = false;

    private void Start()
    {
        new Parser(this).Parse(map.text);
    }

    public void addPoint(float value)
    {
        GameObject go = Instantiate(pointModel, transform);
        go.transform.localPosition += Vector3.right * value * moveSpeed;
        Point point = go.GetComponent<Point>();
        point.game = this;
        point.speed = moveSpeed;
        point.color = Random.value;
    }

    public void addStream(float start, float end)
    {
    }

    private void Update()
    {
        if (start == false)
        {
            gameObject.GetComponent<AudioSource>().Play();
            start = true;
        }
    }

    public void collide(float color)
    {
        ColorPicker.PointType points = picker.getPointType(color);
        switch (points)
        {
            case ColorPicker.PointType.Perfect:
                score += 100;
                break;
            case ColorPicker.PointType.Nice:
                score += 80;
                break;
            case ColorPicker.PointType.Good:
                score += 65;
                break;
            case ColorPicker.PointType.Bad:
                score += 50;
                break;
            case ColorPicker.PointType.Miss:
                if (lives.LostLife())
                {
                    print("Game over");
                }
                break;
        }
    }
}
