using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Raycast : MonoBehaviour
{
	public Camera mainCamera;
    public LayerMask clickable;
    
	void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = mainCamera.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, clickable))
            {
                IClickable validClick = hit.transform.gameObject.GetComponent<IClickable>();
                // Debug.Log("player has clicked: " + validClick);
                if (hit.transform.gameObject.GetComponent<Focus>() != null)
                {
                    Focus focus = hit.transform.gameObject.GetComponent<Focus>();
                    focus.OnClick();
                }
                else if (Inventory.getItem(Inventory.checkSelected()) != null && Inventory.checkSelected() > -1) // player has selected an item in inventory
                {
                    Debug.Log("Player is using " + Inventory.getItem(Inventory.checkSelected()).name + " on " + hit.collider.gameObject.name);
                    Collectable useItem = Inventory.getItem(Inventory.checkSelected());
                    Collider onObject = hit.collider;
                    useItem.use(onObject);
                }
                else
                {
                    validClick.OnClick();
                }
            }
        }
    }
}
