using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField]
    ColorPicker picker;
    public int room;
    private Vector3[] colors;
    public GameObject[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        colors = new Vector3[3];
        colors[0] = new Vector3(-1.5f, -1.5f, 0);
        colors[1] = new Vector3(-1.5f, 1.5f, 0);
        colors[2] = new Vector3(1.5f, 0, 0);
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
        Vector3 expected = new Vector3(picker.transform.position.x + colors[room].x,
            picker.transform.position.y + colors[room].y,
            picker.transform.position.z + colors[room].z);

        print(picker.getPointType(expected).ToString());
        if (picker.getPointType(expected) == ColorPicker.PointType.Perfect && room < 1)
            room += 1;
        if (rooms[room].transform.position.y < 0)
            rooms[room].transform.position = new Vector3(0, rooms[room].transform.position.y + 0.1f, 0);
            
    }
}
