using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input and calculate movement velocity
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;

        // Update animator speed parameter
        animator.SetFloat("Speed", moveVelocity.magnitude);

        // Get firing direction and firing status
        PlayerShooting playerShooting = GetComponent<PlayerShooting>();
        float fireDirectionX = playerShooting.fireDirection.x;
        bool isFiring = playerShooting.getIsFiring();

        // Determine the desired scale based on firing status and movement
        if (isFiring)
        {
            float desiredScaleX = fireDirectionX < 0 
                ? -Mathf.Abs(transform.localScale.x) 
                : Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(desiredScaleX, 
                transform.localScale.y, 
                transform.localScale.z);
        }
        else if (moveVelocity.x != 0)
        {
            float desiredScaleX = moveVelocity.x < 0 
                ? -Mathf.Abs(transform.localScale.x) 
                : Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(desiredScaleX, 
                transform.localScale.y, 
                transform.localScale.z);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
