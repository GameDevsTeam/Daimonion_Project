using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    [SerializeField]
    private LayerMask enemiesLayer;

    Vector2 movement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get Input Values
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        
        if((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0))
        {
            CheckForEncounters();
        }
    }

    void FixedUpdate()
    {
        // Make movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.2f, enemiesLayer) != null)
        {
            if(Random.Range(1, 101) <= 2)
            {
                Debug.Log("Encountered Enemy !");
            }
        }
    }
}
