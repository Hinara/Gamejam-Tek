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
        Vector3 newPos = gameObject.transform.position + new Vector3(x, y, 0) * speed;
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

    uint GetColor()
    {
        float preColor = (getAngle() / (360.0f / colorNo)) + 0.5f;
        if (preColor > colorNo)
        {
            preColor = 0;
        }
        return (uint) preColor;
    }
}
