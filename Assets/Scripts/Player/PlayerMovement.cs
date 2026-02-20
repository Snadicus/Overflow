using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputDetector inputDetector;
    [SerializeField] Rigidbody2D playerRB;
    [Tooltip("Make sure every floor/platform is set to this layer; otherwise, your jump won't reset after landing.")]
    [SerializeField] int floorLayer = 6;
    [Space(20)]
    [SerializeField] float moveSpeed = 10;
    [Tooltip("To adjust \"floatiness,\" modify this value alongside Gravity Scale in Rigidbody2D component.")]
    [SerializeField] float jumpHeight = 15;

    float moveDirection;
    Vector2 playerDirection;

    JumpState jumpState = JumpState.grounded;
    int timesJumped = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputDetector.OnJump += Jump;
    }

    void FixedUpdate()
    {
        Movement();
    }

    #region Logic
    void Movement()
    {
        moveDirection = inputDetector.GetXVelocity();
        playerDirection = new Vector2(moveDirection * moveSpeed, playerRB.linearVelocity.y);

        if(moveDirection != 0f)
        {
            playerRB.linearVelocity = playerDirection;
        }
        else
        {
            playerRB.linearVelocity = new Vector2(0f, playerRB.linearVelocity.y);
        }
    }

    void Jump()
    {
        // Cannot jump again after double jumping
        if(jumpState == JumpState.doubleJumping)
        {
            return;
        }
        
        playerRB.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        AddToJumpState();
    }
    #endregion

    #region Collision
    void OnCollisionStay2D(Collision2D collision)
    {
        // Reset jump after landing on the ground
        if(collision.gameObject.layer == floorLayer)
        {
            ResetJumpState();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        AddToJumpState();
    }
    #endregion

    #region States
    void AddToJumpState()
    {
        ++timesJumped;

        jumpState = (timesJumped >= 2) ? JumpState.doubleJumping : JumpState.jumping;
    }

    void ResetJumpState()
    {
        timesJumped = 0;
        jumpState = JumpState.grounded;
    }
    #endregion

    #region Enum
    enum JumpState
    {
        grounded,
        jumping, 
        doubleJumping
    }
    #endregion
}
