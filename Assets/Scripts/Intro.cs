using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField]
    ColorPicker picker;
    public int room;
    private float[] colors = {
        2.0f / 3.0f,
        1.0f / 3.0f,
        0.0f
    };
    public GameObject[] rooms;
    
    // Start is called before the first frame update
    void Start()
    {
        room = 0;
        foreach (GameObject BackGround in rooms)
        {
            BackGround.transform.position = new Vector3(0, -11.6f, 0);
        }
        rooms[0].transform.position = new Vector3(0, 1.21f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (rooms[room].transform.position.y < 1.21f)
        {
            rooms[room].transform.position += new Vector3(0, 10f, 0) * Time.deltaTime;
            if (room > 0)
                rooms[room - 1].transform.position += new Vector3(0, 10f, 0) * Time.deltaTime;
        }
        else if (picker.getPointType(colors[room]) == ColorPicker.PointType.Perfect)
        {
            room += 1;
            if (room == 3)
                SceneManager.LoadScene("Level1");
        }
    }
}
