using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer[] lives;
    int number;

    private void Start()
    {
        number = lives.Length;
    }

    public bool LostLife()
    {
        if (number == 1)
        {
            return true;
        }
        number -= 1;
        lives[number].enabled = false;
        return false;
    }
}
