using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject vehicle;

    // Start is called before the first frame update
    void Start()
    {
        vehicle = GameObject.Find("Vehicle");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = vehicle.transform.position + new Vector3(25, 10, -10);
    }
}
