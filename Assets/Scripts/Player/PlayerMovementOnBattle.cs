using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOnBattle : MonoBehaviour
{
    // Parameters for player movement
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public static bool playerControlsEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (playerControlsEnabled)
        {
            // Get Input Values
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            // Set Input Values to 0
            movement = new Vector2();
        }
    }
    void FixedUpdate()
    {
        // Make movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
