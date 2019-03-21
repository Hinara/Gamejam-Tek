using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField]
    ColorPicker picker;
    public int room;
    private float[] colors;
    public GameObject[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        colors = new float[3];
        colors[0] = 0.60f;
        colors[1] = 0.45f;
        colors[2] = 0;
        room = 0;
        foreach (GameObject BackGround in rooms)
        {
            BackGround.transform.position = new Vector3(0, -10, 0);
        }
        rooms[0].transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        print(picker.getPointType(colors[room]).ToString());
        if (picker.getPointType(colors[room]) == ColorPicker.PointType.Perfect && room < 1)
            room += 1;
        if (rooms[room].transform.position.y < 0)
            rooms[room].transform.position = new Vector3(0, rooms[room].transform.position.y + 0.1f, 0);
            
    }
}
