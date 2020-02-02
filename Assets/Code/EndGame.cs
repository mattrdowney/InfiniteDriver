using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void Start()
    {
        SoundFactory.AddSound("event:/WINNER", null, null);
    }
    void Update()
    {

        if (Time.timeSinceLevelLoad > 10 || Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();

            if (Time.timeSinceLevelLoad > 4)
            {
                Application.LoadLevel(Application.loadedLevel - 2);

            }
        }
    }
}