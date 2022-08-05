using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Parameters for player movement
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    // Parameter for Battle trigger
    [SerializeField]
    private LayerMask enemiesLayer;

    // Parameters for Battle Scene transition
    BattleLoaderScript battleLoader;
    [SerializeField]
    GameObject battleLoaderCanvas;
    public static bool playerControlsEnabled = true;

    private void Awake()
    {
        // Get animator from player
        animator = GetComponent<Animator>();

        // Get access to LevelLoader script class
        battleLoader = battleLoaderCanvas.GetComponent<BattleLoaderScript>();
    }

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

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // If player moves => Start CheckForEncounters() function
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

    // Function for battle scene trigger
    private void CheckForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.2f, enemiesLayer) != null)
        {
            if(Random.Range(1, 1001) <= 2)
            {
                playerControlsEnabled = false;

                battleLoader.LoadBattleScene("BattleScene");
            }
        }
    }
}
