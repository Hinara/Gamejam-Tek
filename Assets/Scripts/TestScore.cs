using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScore : MonoBehaviour
{
    [SerializeField]
    ColorPicker picker;
    [SerializeField]
    float expected = 0.0f;

    void Update()
    {
        print(picker.getPointType(expected).ToString());
    }
}
