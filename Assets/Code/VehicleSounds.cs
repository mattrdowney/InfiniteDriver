using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSounds : MonoBehaviour
{
    Transform vehicle_transform;
    SoundStruct parameter_test;
    float parameter_value;
    float accel;
    float gear;
    bool isAccel;
    bool isShifting;

    float vehicle_speed = 6f;

    private void Awake()
    {
        
    }

    private void Start()
    {
        vehicle_transform = this.GetComponent<Transform>();
        parameter_test = SoundFactory.AddSound("event:/enginetest", null, null);
        parameter_value = 0f;
        gear = -1;
    }

    private void Update()
    {
        Debug.Log("IsAccel: " + isAccel + " IsShifting: " + isShifting + " Gear: " + gear);
        if(isAccel)
        parameter_test?.modifyFloat("Test", parameter_value);

        if (Input.GetKey(KeyCode.Z))
        {
            isAccel = true;
            gear = 0;
        }
        else if (Input.GetKey(KeyCode.X))
        {
            isAccel = false;
        }
        if(isAccel == true && !isShifting)
        {
            switch (gear)
            {
                case 0:
                    parameter_value += .02f;
                    break;
                case 1:
                    parameter_value += .01f;
                    break;
                case 2:
                    parameter_value += .005f;
                    break;
                case 3:
                    parameter_value += .0025f;
                    break;
                case 4:
                    parameter_value += .0010f;
                    break;
            }
        }
        if (parameter_value >= 10 && gear < 4)
            isShifting = true;

        if(isShifting && parameter_value > 6)
            parameter_value -= 0.03f;

        if(parameter_value <= 6 && isShifting)
        {
            isShifting = false;
            gear += 1f;
        }





        //vehicle_transform.position += Vector3.right * vehicle_speed;
    }
}