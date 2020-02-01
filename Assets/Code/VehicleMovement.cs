using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    Transform vehicle_transform;
    NavigationPath current_navigation;
    NavigationPath next_navigation;
    SoundStruct parameter_test;
    float parameter_value;

    float horizontal_position;
    float vertical_position;
    float angle;
    float vehicle_speed = 6f;

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
        //Debug.Log(parameter_value);

        if (Input.GetKey(KeyCode.Z) && parameter_value > 0)
        {
            parameter_value -= .05f;
            parameter_test?.modifyFloat("Test", parameter_value);
        }
        else if (Input.GetKey(KeyCode.X) && parameter_value < 10)
        {
            parameter_value += .05f;
            parameter_test?.modifyFloat("Test", parameter_value);
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