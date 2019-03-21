using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScore : MonoBehaviour
{
    enum PointType
    {
        Perfect,
        Nice,
        Good,
        Bad,
        Miss
    };

    PointType getPointType()
    {
        float absAngle = Mathf.Abs(Vector3.Angle(Vector3.right, gameObject.transform.position));

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

    // Update is called once per frame
    void Update()
    {
        print(getPointType().ToString());
    }
}
