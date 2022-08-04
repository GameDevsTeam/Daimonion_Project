using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAtPlayer;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    // LateUpdate() execute after Update(), so after the player movement
    private void LateUpdate()
    {
        // Camera vector 2
        Vector3 delta = Vector3.zero;

        // Horizontal Distance between camera and player
        float deltaX = lookAtPlayer.position.x - transform.position.x;

        // If Horizontal Distance is out of bound
        if(deltaX > boundX || deltaX < -boundX)
        {
            // If Camera horizontal position is inferior to player horizontal position
            if(transform.position.x < lookAtPlayer.position.x)
            {
                delta.x = deltaX - boundX;
            }
            // If Camera horizontal position is superior to player horizontal position
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        // Vertical Distance between camera and player
        float deltaY = lookAtPlayer.position.y - transform.position.y;

        // If Vertical Distance is out of bound
        if (deltaY > boundY || deltaY < -boundY)
        {
            // If Camera Vertical position is inferior to player Vertical position
            if (transform.position.y < lookAtPlayer.position.y)
            {
                delta.y = deltaY - boundY;
            }
            // If Camera Vertical position is superior to player Vertical position
            else
            {
                delta.y = deltaY + boundY;
            }
        }
        // Move camera by transforming position with new data
        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}

