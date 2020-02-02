using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDied : MonoBehaviour
{

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        SoundFactory.AddSound("event:/Crashed", null, null);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
