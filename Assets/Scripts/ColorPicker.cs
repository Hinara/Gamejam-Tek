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
    uint colorNo = 3;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        Vector3 newPos = gameObject.transform.position + new Vector3(x, y) * speed;
        if (newPos.magnitude > border)
        {
            newPos = newPos.normalized * border;
        }
        gameObject.transform.position = newPos;

    }

    //Angle is always beetween 0 and 360
    float getAngle()
    {
        Vector3 position = gameObject.transform.position;
        float angle = Vector3.Angle(Vector3.right, position);
        if (position.y < 0)
        {
            angle = 360.0f - angle;
        }
        return angle;
    }

    public uint GetColor()
    {
        float preColor = (getAngle() / (360.0f / colorNo)) + 0.5f;
        if (preColor > colorNo)
        {
            preColor = 0;
        }
        return (uint) preColor;
    }

    public Color GetColorInfinite()
    {
        float angle = getAngle() / 60.0f;

        if (angle <= 1.0f)
        {
            return new Color(1.0f, angle, 0);
        }
        else if (angle <= 2.0f)
        {
            return new Color(1.0f - (angle - 1.0f), 1.0f, 0);
        }
        else if (angle <= 3.0f)
        {
            return new Color(0, 1.0f, (angle - 2.0f));
        }
        else if (angle <= 4.0f)
        {
            return new Color(0, 1.0f - (angle - 3.0f), 1.0f);
        }
        else if (angle <= 5.0f)
        {
            return new Color((angle - 4.0f), 0, 1.0f);
        }
        return new Color(1.0f, 0, 1.0f - (angle - 5.0f));
    }
}
