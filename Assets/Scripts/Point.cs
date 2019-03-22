using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Point : MonoBehaviour
{
    public float speed;
    public float color;
    [SerializeField]
    public Lives lives;
    [SerializeField]
    ColorPicker picker;
    private bool ready;
    public Game game;

    IColorUtils colorUtils = new ColorUtils();

    void Start()
    {
        ready = true;
        picker = GameObject.FindGameObjectWithTag("ColorPicker").GetComponent<ColorPicker>();
        lives = GameObject.FindGameObjectWithTag("Lives").GetComponent<Lives>();
        gameObject.GetComponent<SpriteRenderer>().color = colorUtils.getColor(color);
    }

    void Update()
    {
        transform.localPosition += Vector3.left * speed * Time.deltaTime;
        if (transform.localPosition.x < 0  && transform.localPosition.x > -14 && ready)
        {
            ready = false;
            ColorPicker.PointType got = picker.getPointType(color);
            print(got.ToString());
            if (got == ColorPicker.PointType.Miss)
            {
                if (lives.LostLife() == true)
                    SceneManager.LoadScene("GameOver");
            }
            else
                Destroy(gameObject);
        }
        if (transform.localPosition.x < -10)
        {
            //Destroy(gameObject);
        }
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
