using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField]
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.left * speed * Time.deltaTime;
        if (transform.localPosition.x < 0)
        {
            Destroy(gameObject);
        }
    }
}
