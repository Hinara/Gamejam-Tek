using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Point : MonoBehaviour
{
    public float speed;
    public float color;
    public bool skipLifeLose = false;
    public Game game;
    public string sceneSuccess;

    IColorUtils colorUtils = new ColorUtils();

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = colorUtils.getColor(color);
    }

    void Update()
    {
        transform.localPosition += Vector3.left * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        if (transform.position.x < 0.0f)
        {
            gameObject.tag = "Untagged";
            Destroy(gameObject);
            if (GameObject.FindGameObjectWithTag("Points") == null)
            {
                SceneManager.LoadScene(sceneSuccess);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            game.Collide(color, skipLifeLose);
        }
    }
}
