using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScore : MonoBehaviour
{
    [SerializeField]
    ColorPicker picker;
    // Update is called once per frame
    void Update()
    {
        print(picker.getPointType(0.0f).ToString());
    }
}
