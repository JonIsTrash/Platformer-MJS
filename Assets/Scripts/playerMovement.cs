using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;

    private bool isFacingRight = true;
    private bool doubleJumpAvailable;

    private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        bool grounded = IsGrounded();

        if (grounded)
        {
            coyoteTimeCounter = coyoteTime;
            doubleJumpAvailable = true;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime; //Når player ikke er grounded, så begynder coyote time at tælle ned.
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (coyoteTimeCounter > 0f)
            {
                Jump();
                coyoteTimeCounter = 0f;
            }
            else if (doubleJumpAvailable)
            {
                Jump();
                doubleJumpAvailable = false;
            }
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                rb.linearVelocity.y * 0.5f
            );
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(
            horizontal * speed,
            rb.linearVelocity.y
        );
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpingPower
        );
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(
            groundCheck.position,
            0.2f,
            groundLayer
        );
    }

    private void Flip() //Spørger efter jumo knappen, efter man har givet slip.
    {
        if ((isFacingRight && horizontal < 0f) ||
            (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;

            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}