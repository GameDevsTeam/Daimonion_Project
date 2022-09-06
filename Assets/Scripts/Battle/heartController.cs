using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movement parameters")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveHorizontal;
    [SerializeField] private float moveVertical;

    [Header("Dash parameters")]
    [SerializeField] private float dashingPower;
    [SerializeField] private float dashingTime;
    [SerializeField] private float dashCooldown;
    private Vector2 dashingDir;
    bool canDash;
    bool isDashing;
    private TrailRenderer tr;


    [Header("Jumping parameters")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpTime;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private bool isJumping;
    [SerializeField] private float checkRadius;
    float jumpCounter;
    Vector2 vecGravity;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header("Gameplay type")]
    public bool isTopDown;
    public bool isPlatformer;


    // Start is called before the first frame update
    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        moveSpeed = 3f;

        canDash = true;
        isDashing = false;
        dashingPower = 7f;
        dashingTime = 0.2f;
        dashCooldown = 2.0f;
        tr = gameObject.GetComponent<TrailRenderer>();

        jumpForce = 4f;
        jumpTime = 0.3f;
        fallMultiplier = 0f;
        jumpMultiplier = 1.5f;
        isJumping = false;
        checkRadius = 0.1f;
        
        isTopDown = true;
        isPlatformer = false;

    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if (isTopDown)
        {
            // No gravity
            rb2D.gravityScale = 0f;

            // Dash
            if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                dashingDir = new Vector2(moveHorizontal, moveVertical);
                if(dashingDir == Vector2.zero)
                {
                    return;
                }
                isDashing = true;
                canDash = false;
                tr.emitting = true;
                StartCoroutine(stopDashing());
            }
        }
        if (isPlatformer)
        {
            // Set Gravity Back
            rb2D.gravityScale = 1.5f;

            // Dash
            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                dashingDir = new Vector2(moveHorizontal, 0);
                if (dashingDir == Vector2.zero)
                {
                    return;
                }
                isDashing = true;
                canDash = false;
                tr.emitting = true;
                StartCoroutine(stopDashing());
            }

            // Jump system
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
                isJumping = true;
                jumpCounter = 0;
            }

            if(rb2D.velocity.y > 0f && isJumping)
            {
                jumpCounter += Time.deltaTime;
                if(jumpCounter > jumpTime) isJumping = false;

                float t = jumpCounter / jumpTime;
                float currentJumpM = jumpMultiplier;
                if (t > 0.5f)
                {
                    currentJumpM = jumpMultiplier * (1 - t);
                }

                rb2D.velocity += vecGravity * jumpMultiplier * Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;

                if(rb2D.velocity.y > 0f)
                {
                    rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.6f);
                }
            }
            
            if(rb2D.velocity.y < 0f)
            {
                rb2D.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
            }

        }
    }

    private void FixedUpdate()
    {
        if (isTopDown)
        {
            // Dash
            if (isDashing)
            {
                rb2D.velocity = new Vector2(dashingDir.x * dashingPower, dashingDir.y * dashingPower);
                return;
            }

            // Movement
            rb2D.velocity = new Vector2(moveHorizontal * moveSpeed, moveVertical * moveSpeed);
        }

        if (isPlatformer)
        {
            // Dash
            if (isDashing)
            {
                rb2D.velocity = new Vector2(dashingDir.x * dashingPower, 0);
                return;
            }

            // Movement
            rb2D.velocity = new Vector2(moveHorizontal * moveSpeed, rb2D.velocity.y);
        }
    }

    bool isGrounded()
    {
        // Check if grounded => (return bool)
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    private IEnumerator stopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
