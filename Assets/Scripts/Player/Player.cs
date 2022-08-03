using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    private Vector2 movement;

    public LayerMask enemiesLayer;

    private void Start()
    {
        // Get Rigidbody2D
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get Input Values
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // Swap sprite direction
        if (movement.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Make movement
        rigidBody2D.MovePosition(rigidBody2D.position + movement * Time.fixedDeltaTime);

        // Enemies encounter
        CheckForEncounters();
    }

    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, enemiesLayer) != null)
        {
            if (Random.Range(1,101) <= 10)
            {
                Debug.Log("Encountered an enemy !");
            }
        }
    }
}
