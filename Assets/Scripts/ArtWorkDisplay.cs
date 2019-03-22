using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArtWorkDisplay : MonoBehaviour
{
    IColorUtils colorUtils = new ColorUtils();
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("return"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
