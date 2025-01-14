using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform GFX;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;

    public float crouchHeight = 0.5f;

    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;

    private bool isGrounded = false;
    private bool isJumping = false;

    private float jumpTimer;

    private void Awake()
    {
        GFX = GetComponent<Transform>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.linearVelocity = Vector2.up * jumpForce; // Initial jump impulse
            jumpTimer = 0f; // Reset the jump timer when starting a new jump
        }

        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.linearVelocity = Vector2.up * jumpForce; // Apply continuous upward force
                jumpTimer += Time.deltaTime; // Increment the jump timer
            }
            else
            {
                isJumping = false; // Stop jumping if the jump time has elapsed
            }
        }

        if (!Input.GetButton("Jump"))
        {
            isJumping = false; // Stop jumping if the jump button is released
        }
        #region CROUCHING

        if (isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);
        }
        if (isJumping && Input.GetKey(KeyCode.LeftShift))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, 1f, GFX.localScale.z);
        }
       

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, 1f, GFX.localScale.z);
        }

        #endregion
    }
}

