using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Move Settings")]

    [SerializeField]
    float speed;

    [SerializeField]
    float sprintSpeed;

    [SerializeField]
    float walkSpeed;

    [Header("Jump Settings")]

    [SerializeField]
    float jumpForce;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    Transform groundChecker;

    [SerializeField]
    float groundCheckRadius;

    [SerializeField]
    float liftForce;

    [SerializeField]
    float maxLiftVelocity;

    float flightVelocity = 0;
    bool isFlying;

    Vector2 moveInput;
    Rigidbody rb;
    bool isOnGround;
    bool knockedBack = false;
    Vector3 startPosition;

    PlayerLookController playerLookController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerLookController = GetComponent<PlayerLookController>();
        startPosition = transform.position;
    }

    void Update()
    {
        GetMoveInput();
        SetIsOnGround();
        GetJumpInput();
        CheckForFall();
    }

    private void FixedUpdate()
    {
        if (!knockedBack)
        {
            rb.velocity = GetMoveVelocity();
        }

        if (isFlying)
        {
            flightVelocity += liftForce * Time.deltaTime;
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp(rb.velocity.y + flightVelocity, float.MinValue, maxLiftVelocity), rb.velocity.z);
        }
    }

    void GetMoveInput()
    {
        moveInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        if (moveInput == Vector2.zero && isOnGround && !Input.GetKey(KeyCode.Space))
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
        } 
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }

        if (Input.GetKey(KeyCode.LeftShift) && moveInput.y == 1)
        {
            speed = sprintSpeed;
        } 
        else
        {
            speed = walkSpeed;
        }
    }

    void CheckForFall()
    {
        if (transform.position.y < - 10)
        {
            transform.position = startPosition;
        }
    }

    Vector3 GetMoveVelocity()
    {
        if (!isOnGround)
            return rb.velocity;

        Vector3 velocity = Vector3.zero;
        velocity += transform.right * moveInput.x;
        velocity += transform.forward * moveInput.y;
        velocity.Normalize();
        velocity *= speed;
        return new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    void SetIsOnGround()
    {
        if (Physics.OverlapSphere(groundChecker.position, groundCheckRadius, groundLayer).Length > 0)
        {
            knockedBack = false;
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }

    void GetJumpInput()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            Jump();
        } 
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(playerLookController.GetForwardVector() * 20, ForceMode.Impulse);
            flightVelocity = 0;
            isFlying = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) || isOnGround)
        {
            flightVelocity = 0;
            isFlying = false;
        }
    }

    public void KnockBack()
    {
        knockedBack = true;
    }
}
