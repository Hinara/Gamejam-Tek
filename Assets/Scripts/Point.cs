using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public float speed;
    public float color;

    IColorUtils colorUtils = new ColorUtils();

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = colorUtils.getColor(color);
    }

    void Update()
    {
        transform.localPosition += Vector3.left * speed * Time.deltaTime;
        if (transform.localPosition.x < 0)
        {
            Destroy(gameObject);
        }
    }
}
