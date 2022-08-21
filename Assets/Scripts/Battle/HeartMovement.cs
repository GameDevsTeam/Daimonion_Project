using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMovement : MonoBehaviour
{
    private Vector3 startingPosition = Vector3.zero;
    public float speed;
    public int minX = -2;
    public int maxX = 2;
    public int minY = -2;
    public int maxY = 2;
    public Rigidbody2D rb;
    private Vector2 dashingDir;
    public bool canDash = true;
    public bool isDashing = false;
    public float dashingPower = 1f;
    public float dashingTime = 0.2f;
    public float dashCooldown = 2.0f;
    [SerializeField] private TrailRenderer tr;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        setHeart();
    }

    public void setHeart()
    {
        transform.position = startingPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
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

    private void FixedUpdate()
    {
        var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        var pos = (Vector2)transform.position + direction * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        rb.MovePosition(pos);
        
        if (isDashing)
        {
            rb.MovePosition((Vector2)transform.position + new Vector2(dashingDir.x * dashingPower, dashingDir.y * dashingPower));
            return;
        }
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
