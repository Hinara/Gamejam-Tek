using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolling : MonoBehaviour
{
    public float speed;
    public Sprite sprite;
    public GameObject[] floor;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject ground in floor)
            ground.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject ground in floor)
        {
            if (ground.transform.position.x < -20)
                ground.transform.position = new Vector3(20, -4f, 0);
            else
                ground.transform.position = new Vector3(ground.transform.position.x - (speed / 100), -4f, 0);
        }
    }
}
