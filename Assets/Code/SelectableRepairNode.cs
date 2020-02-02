using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableRepairNode : MonoBehaviour
{
    private Camera main_camera;
    public GameObject pathfinding_route;
    public Vector3 unselected_position;
    public Vector3 spawn_offset;

    public char hotkey;
    
    void Start()
    {
        main_camera = GameObject.FindObjectOfType<Camera>();
        RepairNodeSelector.buildings[hotkey] = this;
    }
    
    void Update()
    {
        if (hotkey == RepairNodeSelector.selected)
        {
            Ray ray = main_camera.ScreenPointToRay(Input.mousePosition);
            transform.position = ray.GetPoint(-main_camera.transform.position.z);
        }
        else
        {
            transform.localPosition = unselected_position;
        }
    }
}
