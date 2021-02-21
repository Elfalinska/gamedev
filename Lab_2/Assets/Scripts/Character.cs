using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Character : Unit
{
    private int lives = 5;
    private float speed = 3.0f;
    private float jumpForce = 15.0f;
    private bool isGrounded = false;
    public string name;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 5) lives = value;
            livesBar.Refresh();
        }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private LivesBar livesBar;

    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        name = PlayerPrefs.GetString("Name");
    }

    private void FixedUpdate()
    {
        checkGround();
        if (Lives <= 0)
        {
            SceneManager.LoadScene("Main");
        }
    }

    // Update is called once per frame
    void Update()
    {
        State = CharState.idle;
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButtonDown("Jump")) Jump(); 
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0f;
        State = CharState.run;
    }

    private void Jump()
    {
        State = CharState.jump;
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    public override void ReceiveDamage()
    {
        Lives--;

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(-transform.right * 8.0f, ForceMode2D.Impulse);
    }

    private void checkGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = colliders.Length > 1;
    }
}


public enum CharState
{
    idle,
    run,
    jump
}
