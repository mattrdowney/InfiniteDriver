using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    Transform vehicle_transform;
    NavigationPath current_navigation;
    NavigationPath next_navigation;

    float horizontal_position;
    float vertical_position;
    float angle;
    float vehicle_speed = 6f;
    
    SoundStruct parameter_test;
    float parameter_value;
    float accel;
    float gear;
    bool isAccel;
    bool isShifting;

    private void Awake()
    {
        horizontal_position = 0;
        vertical_position = 0;
    }

    private void Start()
    {
        vehicle_transform = this.GetComponent<Transform>();
        parameter_test = SoundFactory.AddSound("event:/enginetest", null, null);
        parameter_value = 0f;
    }

    private void Update()
    {
        Debug.Log("IsAccel: " + isAccel + " IsShifting: " + isShifting + " Gear: " + gear);

        if(isAccel)
        parameter_test?.modifyFloat("Test", parameter_value);

        if (transform.position.y>=0)
        {
            isAccel = true;
            gear = 0;
        }
        else if (true)
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
    }

    private void FixedUpdate()
    {
        if (next_navigation != null)
        {
            if (Time.timeSinceLevelLoad > next_navigation.start_time)
            {
                if (next_navigation != current_navigation)
                {
                    current_navigation = next_navigation;
                    next_navigation = null;
                }
            }
        }
        if (current_navigation != null)
        {
            horizontal_position = current_navigation.transform.position.x +
                    current_navigation.x_path.Evaluate(Time.timeSinceLevelLoad - current_navigation.start_time);
            vertical_position = current_navigation.transform.position.y +
                    current_navigation.y_path.Evaluate(Time.timeSinceLevelLoad - current_navigation.start_time);

            angle = current_navigation.angle.Evaluate(Time.timeSinceLevelLoad - current_navigation.start_time);
        }

        transform.position = new Vector3(horizontal_position, vertical_position, 0f);
        transform.eulerAngles = new Vector3(0, 0, angle);

        //this.transform.position = new Vector3(horizontal_position, vertical_position, 0);

        // Player exists on an AnimationCurve.
        // When Player colides with ConstructedSite, follow a new AnimationCurve when position.x is greater than site's threshold
        // Customizable thresholds would almost always be site.transform.position.x - site.transform.scale.x/2
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("colliding");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Hazard"))
        {
            Debug.Log(collision.gameObject.name);
            List<SoundStruct> temporary_list = new List<SoundStruct>() { parameter_test };
            SoundFactory.DeleteSound(ref temporary_list, "event:/enginetest");
            Application.LoadLevel(Application.loadedLevel);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Goal"))
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Navigation"))
        {
            NavigationPath pathfinding = collision.gameObject.GetComponent<NavigationPath>();
            if (pathfinding != null)
            {
                Debug.Log("Happening10");
                next_navigation = pathfinding;
            }
        }
    }
}