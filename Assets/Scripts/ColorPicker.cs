using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    [SerializeField]
    float border = 0.0f;
    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    Transform picker;
    [SerializeField]
    SpriteRenderer[] sprites;

    IColorUtils colorUtils = new ColorUtils();

    public enum PointType
    {
        Perfect,
        Nice,
        Good,
        Bad,
        Miss
    };


    float getDiff(float f1, float f2)
    {
        float res = Mathf.Abs(f1 - f2);
        if (res > 0.5f)
        {
            res = 1.0f - res;
        }
        print(res);
        return res;
    }

    public PointType getPointType(float expected)
    {
        float absAngle = getDiff(expected, getValue()) * 360.0f;

        if (absAngle < 8.0f)
        {
            return PointType.Perfect;
        }
        if (absAngle < 25.0f)
        {
            return PointType.Nice;
        }
        if (absAngle < 55.0f)
        {
            return PointType.Good;
        }
        if (absAngle < 90.0f)
        {
            return PointType.Bad;
        }
        return PointType.Miss;
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        UpdatePosition();
        Color color = GetColor();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.color = color;
        }
    }

    void UpdatePosition()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        Vector3 newPos = picker.transform.localPosition + new Vector3(x, y) * speed;
        if (newPos.magnitude > border)
        {
            newPos = newPos.normalized * border;
        }
        picker.transform.localPosition = newPos;

    }

    //Angle is always beetween 0 and 1
    float getValue()
    {
        Vector3 position = picker.transform.localPosition;
        float angle = Vector3.Angle(Vector3.right, position);
        if (position.y < 0)
        {
            angle = 360.0f - angle;
        }
        return angle / 360.0f;
    }

    public Color GetColor()
    {
        return colorUtils.getColor(getValue());
    }
}
