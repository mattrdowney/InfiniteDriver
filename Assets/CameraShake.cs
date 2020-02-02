﻿using UnityEngine;
using System.Collections;

// http://www.mikedoesweb.com/2012/camera-shake-in-unity/

public class CameraShake : MonoBehaviour
{

    private Vector3 originPosition;
    private Quaternion originRotation;
   // public float shake_decay = 0.002f;
    public float shake_intensity = .7f;
    float timeToGoBack = 3f;

    private float temp_shake_intensity = 0;

    void Start()
    {
        SoundFactory.AddSound("event:/Crashed", null, null);
    }


    void Update()

    {
        timeToGoBack -= Time.deltaTime;

        if(timeToGoBack <= 0)
            Application.LoadLevel(Application.loadedLevel - 2);
        Shake();
        if (temp_shake_intensity > 0)
        {
            transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
            /*transform.rotation = new Quaternion(
                originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);*/
            //temp_shake_intensity -= shake_decay;
        }
    }

    void Shake()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        temp_shake_intensity = shake_intensity;

    }
}