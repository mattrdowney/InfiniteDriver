using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    Transform vehicle_transform;
    SoundStruct parameter_test;
    float parameter_value;

    float vehicle_speed = 6f;

    private void Awake()
    {
        
    }

    private void Start()
    {
        vehicle_transform = this.GetComponent<Transform>();
        parameter_test = SoundFactory.AddSound("event:/enginetest", null, null);
        parameter_value = 0.5f;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            parameter_value -= .5f;
            parameter_test.modifyFloat("Test", parameter_value);
        }
        else if (Input.GetKey(KeyCode.X))
        {
            parameter_value += .5f;
            parameter_test.modifyFloat("Test", parameter_value);
        }
        
        //vehicle_transform.position += Vector3.right * vehicle_speed;
    }
}