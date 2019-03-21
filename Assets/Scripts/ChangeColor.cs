using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField]
    ColorPicker picker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = ConvertColor();
    }

    Color ConvertColor()
    {

        if (picker == null)
        {
            return Color.black;
        }
        uint value = picker.GetColor();

        switch (value)
        {
            case 0:
                return Color.red;
            case 1:
                return Color.yellow;
            case 2:
                return Color.green;
            case 3:
                return Color.cyan;
            case 4:
                return Color.blue;
            case 5:
                return Color.magenta;
            default:
                return Color.black;
        }
    }
}
