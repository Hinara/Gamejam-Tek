using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField]
    TextAsset map;
    [SerializeField]
    float moveSpeed = 1e4f;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject pointModel;
    [SerializeField]
    GameObject streamModel;
    [SerializeField]
    Lives lives;
    [SerializeField]
    ColorPicker picker;
    [SerializeField]
    Transform entityBase;
    [SerializeField]
    TextMesh scoreText;
    [SerializeField]
    float shiftedStart = 3.0f;

    uint score = 0;
    bool start = false;

    private void Start()
    {
        scoreText.GetComponent<MeshRenderer>().sortingLayerName = "Picker";
        scoreText.text = "0";
        new Parser(this).Parse(map.text);
        gameObject.GetComponent<AudioSource>().clip.LoadAudioData();
    }

    public void addPoint(float value)
    {
        GameObject go = Instantiate(pointModel, entityBase);
        go.transform.localPosition += Vector3.right * (shiftedStart + value) * moveSpeed;
        Point point = go.GetComponent<Point>();
        point.game = this;
        point.speed = moveSpeed;
        point.color = Random.value;
    }

    public void addStream(float start, float end)
    {
        GameObject go = Instantiate(streamModel, entityBase);
        go.transform.localPosition += Vector3.right * (shiftedStart + start) * moveSpeed;
        Stream stream = go.GetComponent<Stream>();
        stream.game = this;
        stream.speed = moveSpeed;
        stream.color = Random.value;
        stream.duration = end - start;
    }

    private void Update()
    {
        if (start == false)
        {
            gameObject.GetComponent<AudioSource>().PlayDelayed(shiftedStart);
            start = true;
        }
    }

    void OnBecameInvisible()
    {
        if (transform.localPosition.x < 0)
            Destroy(gameObject);
    }

    public void Collide(float color, bool skipLifeLose)
    {
        ColorPicker.PointType points = picker.getPointType(color);
        switch (points)
        {
            case ColorPicker.PointType.Perfect:
                score += 100;
                break;
            case ColorPicker.PointType.Nice:
                score += 80;
                break;
            case ColorPicker.PointType.Good:
                score += 65;
                break;
            case ColorPicker.PointType.Bad:
                score += 50;
                break;
            case ColorPicker.PointType.Miss:
                if (!skipLifeLose && lives.LostLife())
                {
                    SceneManager.LoadScene("GameOver");
                }
                return;
        }
        scoreText.text = score.ToString();
    }
}
