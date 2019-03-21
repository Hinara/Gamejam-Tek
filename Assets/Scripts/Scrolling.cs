using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float speed;
    public GameObject[] floor;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject ground in floor)
        {
            if (ground.transform.position.x < -20)
                ground.transform.position += new Vector3(40, 0, 0);
            else
                ground.transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
