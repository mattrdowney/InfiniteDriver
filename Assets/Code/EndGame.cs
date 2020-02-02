using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void Update()
    {
        if (Time.timeSinceLevelLoad > 10 || Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}