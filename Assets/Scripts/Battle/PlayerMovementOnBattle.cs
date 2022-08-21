using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOnBattle : MonoBehaviour
{
    private Vector3 startingPosition = new Vector3(0, -79, 0);

    public float speed;
    private Vector2 movePosition;

    public int minX = -2;
    public int maxX = 2;
    public int minY = -2;
    public int maxY = 2;

    private void Start()
    {
        setHeart();
    }

    public void setHeart()
    {
        transform.position = startingPosition;
        movePosition = startingPosition;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movePosition.x += horizontal;
        movePosition.y += vertical;

        movePosition.x = Mathf.Clamp(movePosition.x, minX, maxX);
        movePosition.y = Mathf.Clamp(movePosition.y, minY, maxY);

        transform.position = Vector2.Lerp(transform.position, movePosition, speed * Time.deltaTime);
    }

    /*// Parameters for player movement
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public static bool playerControlsEnabled = true;
    public bool canDash = true;
    public bool isDashing = false;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    public float dashCooldownDuration = 2.0f;

    [SerializeField] private TrailRenderer tr;

    // Update is called once per frame
    void Update()
    {
        if(isDashing)
        {
            return;
        }

        if (playerControlsEnabled)
        {
            // Get Input Values
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                StartCoroutine(Dash());
                *//*rb.velocity = new Vector2(transform.localScale.x * 24f, 0f);*/
    /*UseDash();*//*
}
}
else
{
// Set Input Values to 0
movement = new Vector2();
}
}
void FixedUpdate()
{
if(isDashing)
{
return;
}
// Make movement
rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
*//*rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);*//*
}

*//*public void UseDash()
{
    if(canDash == false)
    {
        return;
    }
    Debug.Log("IN");
    movement *= 2f;
    StartCoroutine(StartCooldown());
}*//*

public IEnumerator Dash()
{
    canDash = false;
    isDashing = true;
    *//*rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime * dashingPower);*//*
    rb.velocity = new Vector2(transform.localScale.x * dashingPower, transform.localScale.y * dashingPower);
    tr.emitting = true;
    yield return new WaitForSeconds(dashingTime);
    tr.emitting = false;
    isDashing = false;
    yield return new WaitForSeconds(dashCooldownDuration);
    canDash = true;
}*/
}
