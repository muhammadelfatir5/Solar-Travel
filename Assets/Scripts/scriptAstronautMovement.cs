using NUnit.Framework;
using UnityEngine;

public class scriptAstronautMovement : MonoBehaviour
{
    public float speed = 2f;
    public float jumpForce = 10f;

    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Collider2D playerCollider;

    private bool isGrounded;
    private float moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        isGrounded = playerCollider.IsTouchingLayers(groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);        
    }
}
