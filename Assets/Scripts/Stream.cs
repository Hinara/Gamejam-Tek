using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    public float speed;
    public float color;
    public float duration;
    public GameObject model;
    public Game game;

    void Start()
    {
        float modelWidth = model.GetComponent<SpriteRenderer>().bounds.size.x * 2.0f / 3.0f;
        spawnPoint(0.0f);
        for (float f = 0.0f; f < duration * speed; f += modelWidth)
        {
            spawnPoint(f);
        }
        spawnPoint(duration * speed);
    }

    void Update()
    {
        transform.localPosition += Vector3.left * speed * Time.deltaTime;
    }

    void spawnPoint(float value)
    {
        GameObject newPoint = Instantiate(model, transform);
        newPoint.transform.localPosition = Vector3.right * value;
        Point point = newPoint.GetComponent<Point>();
        point.color = color;
        point.speed = 0;
        point.game = game;
    }
}
