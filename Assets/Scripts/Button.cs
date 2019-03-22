using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour
{
    public string nextScene;

    // Start is called before the first frame update
    private void OnMouseDown()
    {
        SceneManager.LoadScene(nextScene);
    }
}
