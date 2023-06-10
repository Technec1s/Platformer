using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioSource jumpSourceEffect;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public int maxJumps = 2;
    public static Vector2 lastCheckPointPos = new Vector2(-53.81f, 6f);

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private int jumpsRemaining;
    private float moveX = 0f;

    private enum MovementState {idle, running, jumping, falling}

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        jumpsRemaining = maxJumps;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            Jump();
            jumpSourceEffect.Play();
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (moveX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else if (moveX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpsRemaining--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            jumpsRemaining = maxJumps;
        }
    }
}