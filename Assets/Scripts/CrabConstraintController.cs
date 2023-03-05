using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabConstraintController : MonoBehaviour
{
    Vector3 originalPosition;// Store the original position of the leg
    public GameObject moveCube; // Reference to the move cube objec
    public float legMoveSpeed = 7f; // The speed at which the leg moves
    public float moveDistance = 0.7f;  // The maximum distance the leg can move away from the original position
    public float moveStoppingDistance = 0.4f;// The minimum distance the leg must reach before stopping
    public CrabConstraintController oppsiteLeg; // Reference to the opposite leg object
    bool isMoving = false;   // Boolean to check if the leg is currently moving
    bool moving = false; // Boolean to control the movement of the leg

    private void Start()
    {
        originalPosition = transform.position; // Store the original position of the leg in the Start method
    }

    private void Update()
    {
        float distanceToMoveCube = Vector3.Distance(transform.position, moveCube.transform.position);// Calculate the distance between the leg and the move cube

        // Check if the leg is within the move distance and if the opposite leg is not moving

        if ((distanceToMoveCube >= moveDistance && !oppsiteLeg.isItMoving()) || moving)
        {
            // Start moving the leg towards the move cube
            moving = true; 
            transform.position = Vector3.Lerp(transform.position, moveCube.transform.position + new Vector3(0f, 0.6f, 0f), Time.deltaTime * legMoveSpeed);
            originalPosition = transform.position; // Update the original position to the new position
            isMoving = true;// Set the isMoving flag to true
            // Check if the leg has reached the minimum stopping distance
            if (distanceToMoveCube < moveStoppingDistance) 
            {
                moving = false; 
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition + new Vector3(0f, -0.3f, 0f), Time.deltaTime * legMoveSpeed * 3f); // Move the leg back to its original position
            isMoving = false;  // Set the isMoving flag to false
        }
    }
    // Method to check if the leg is moving
    public bool isItMoving() 
    {
        return isMoving;
    }
}
