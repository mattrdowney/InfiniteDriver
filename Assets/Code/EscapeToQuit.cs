using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeToQuit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > 30 || Input.GetKeyUp(KeyCode.Escape))
        {
#if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }
    }
}
