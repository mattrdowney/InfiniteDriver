using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairNodeSelector : MonoBehaviour
{
    Camera main_camera;
    public static SelectableRepairNode[] buildings;
    
    public static char selected = '\0';
    private static bool mouse_selected;

    private void Awake()
    {
        buildings = new SelectableRepairNode[(int) 'w' + 1];
    }

    // Start is called before the first frame update
    void Start()
    {
        main_camera = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Select repair items with mouse
        if (selected == '\0' && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = main_camera.ScreenPointToRay(Input.mousePosition);

            Debug.Log("Here");
            if (Physics.Raycast(ray, out hit, 1000, 1 << LayerMask.NameToLayer("UI")))
            {
                Debug.Log("Here2");
                Transform objectHit = hit.transform;

                // Do something with the object that was hit by the raycast.

                SelectableRepairNode ui_element = objectHit.GetComponent<SelectableRepairNode>();
                selected = ui_element.hotkey;
                mouse_selected = true;
            }
        }
        else if ((mouse_selected && Input.GetMouseButtonUp(0)) || (!mouse_selected && selected != '\0' && Input.GetMouseButtonDown(0)))
        {
            RaycastHit hit;
            Ray ray = main_camera.ScreenPointToRay(Input.mousePosition);

            Debug.Log("Here3");
            if (Physics.Raycast(ray, out hit, 1000, 1 << LayerMask.NameToLayer("Build")))
            {
                Debug.Log("Here4");
                Transform objectHit = hit.transform;

                // Do something with the object that was hit by the raycast.

                Debug.Log(objectHit.name);
                Debug.Log(objectHit.gameObject.layer);
                ConstructionNode construction_site = objectHit.GetComponentInChildren<ConstructionNode>();
                construction_site.construct(buildings[selected]);
            }
            
            selected = '\0';
            mouse_selected = false;
        }

        KeyCode[] hotkeys = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R };
        // Select repair items with hotkeys (priority)
        foreach (KeyCode key in hotkeys)
        {
            if (Input.GetKeyDown(key))
            {
                selected = (char)key;
                mouse_selected = false;
            }
            else if (Input.GetKeyUp(key) && (char) key == selected)
            {
                selected = '\0';
                mouse_selected = false;
            }
        }
    }
}