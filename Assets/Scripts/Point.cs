using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public float speed;
    public float color;
    public Game game;

    IColorUtils colorUtils = new ColorUtils();

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = colorUtils.getColor(color);
    }

    void Update()
    {
        transform.localPosition += Vector3.left * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("collide");
        if (collision.gameObject.CompareTag("Player"))
        {
            print("test");
            game.collide(color);
        }
    }
}
