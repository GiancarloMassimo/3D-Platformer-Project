using System.Collections;
using Unity.VisualScripting;
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
    public bool isFlying;
    bool SlowOr;

    Vector2 moveInput;
    Rigidbody rb;
    bool isOnGround;
    public bool knockedBack = false;
    public bool isControlEnabled = true;
    Vector3 startPosition;
    bool canResetKnockedBack = false;
    bool stuck = false;

    [SerializeField]
    AudioSource flySound, landSound, impactSound;

    PlayerLookController playerLookController;

    float timeBetweenLastW = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerLookController = GetComponent<PlayerLookController>();
        startPosition = transform.position;
        flySound.volume = GameSettings.soundVolume;
    }
    
    void Update()
    {
        timeBetweenLastW += Time.deltaTime;

        GetMoveInput();
        SetIsOnGround();
        GetJumpInput();
        CheckForFall();
       
    }

   

    private void FixedUpdate()
    {
        if (stuck) return;

        if (!knockedBack)
        {
            rb.velocity = GetMoveVelocity();

            if (moveInput == Vector2.zero && isOnGround && !Input.GetKey(KeyCode.Space))
            {
                rb.constraints = RigidbodyConstraints.FreezePosition;
            }
            else
            {
                rb.constraints = RigidbodyConstraints.None;
            }

            if (isFlying)
            {
                flightVelocity += liftForce * Time.deltaTime;
                rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp(rb.velocity.y + flightVelocity, float.MinValue, maxLiftVelocity), rb.velocity.z);
            }
        } 
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        

    }

    void GetMoveInput() { 
        moveInput = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (timeBetweenLastW < 0.25f)
            {
                speed = sprintSpeed;
            }
            else
            {
                speed = walkSpeed;
            }

            timeBetweenLastW = 0;
        }

        if (moveInput.y != 1)
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
        if (!isControlEnabled)
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
            if (canResetKnockedBack)
            {
                knockedBack = false;
            }
            isControlEnabled = true;

            if (!isOnGround)
            {
                landSound.Play();
            }

            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }

    void GetJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Jump();
        } 
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround)
        {
            flySound.Play();
            rb.velocity = Vector3.zero;
            rb.AddForce(playerLookController.GetForwardVector() * 20, ForceMode.Impulse);
            flightVelocity = 0;
            isFlying = true;
            isControlEnabled = false;
        }

        if (Input.GetKeyUp(KeyCode.Space) || isOnGround)
        {
            flightVelocity = 0;
            isFlying = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            impactSound.Play();
            stuck = false;
            transform.position = startPosition;
        }
    }

    public void KnockBack()
    {
        knockedBack = true;
        canResetKnockedBack = false;
        StartCoroutine(DelayKnockBackReset());
    }

    public void Stick()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        stuck = true;
    }

    IEnumerator DelayKnockBackReset()
    {
        yield return new WaitForSeconds(0.25f);
        canResetKnockedBack = true;
    }
}
