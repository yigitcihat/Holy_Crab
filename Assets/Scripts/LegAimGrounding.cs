using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegAimGrounding : MonoBehaviour
{
    private int layerMask;// The layer mask used to identify the ground layer
    private GameObject raycastOrigin; // The origin of the raycast used to detect the ground
    void Start()
    {
        layerMask = LayerMask.GetMask("Ground"); // Get the layer mask for the "Ground" layer
        raycastOrigin = transform.parent.gameObject;// Get the origin of the raycast (the parent of this game object)
    }


    void Update()
    {
        RaycastHit hit; // Raycast downward from the raycast origin to detect the ground
        if (Physics.Raycast(raycastOrigin.transform.position, -transform.up, out hit, Mathf.Infinity, layerMask))
        {
            transform.position = hit.point + new Vector3(0f, 0.3f, 0f);  // If the raycast hits the ground, set the position of this game object to the hit point plus an offset
        }

    }
}