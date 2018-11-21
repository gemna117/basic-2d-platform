using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatformerController : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = true;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundChceck;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        grounded = Physics2D.Linecast(transform.position, groundChceck.position, 1 << LayerMask.NameToLayer("ground"));

        if (Input.GetButtonDown("jump") && grounded)
        {
            jump = true;
        }
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("horizontal");
        anim.SetFloat("speed", Mathf.Abs(h));

        if(h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2 (Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            flip();
        else if (h < 0 && facingRight)
            flip();

        if(jump)
        {
            anim.SetTrigger("jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x += -1;
        transform.localScale = theScale;
    }
}
