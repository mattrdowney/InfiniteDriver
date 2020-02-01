using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    Transform vehicle_transform;

    float vehicle_speed = 6f;

    private void Awake()
    {
        
    }

    private void Start()
    {
        vehicle_transform = this.GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        vehicle_transform.position += 
    }
}