using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionNode : MonoBehaviour
{
    private GameObject player;
    public GameObject pathfinding_route;
    private bool already_constructed = false;

    public void Start()
    {
        player = GameObject.Find("Vehicle");
    }

    public void construct(SelectableRepairNode repair)
    {
        if (!already_constructed)
        {
            if (pathfinding_route != null)
            {
                GameObject.Destroy(pathfinding_route);
            }
            GameObject.Instantiate(repair.pathfinding_route, this.transform.position, Quaternion.identity);
        }
    }
}