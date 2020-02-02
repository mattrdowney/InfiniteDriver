using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    void Update()
    {
        if (Time.timeSinceLevelLoad > 4 || Input.GetKeyUp(KeyCode.Escape))
        {
#if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }
    }
}