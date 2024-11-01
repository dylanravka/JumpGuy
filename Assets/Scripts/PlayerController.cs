using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody2D rigidBody;

    public float jumpForce;
    public float movementSpeed;


    private bool isJumping = false;

    private Vector3 initScale = new Vector3();

    private Vector3 initPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

        initScale = transform.localScale;
        initPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                rigidBody.AddForce(jumpForce * new Vector2(0.0f, 1.0f));
                isJumping = true;
                playerAnim.SetTrigger("Jump");
                playerAnim.SetBool("isGrounded", false);
            }
        }


        float horizontalInput = Input.GetAxis("Horizontal");

        float horizontalMovement = horizontalInput * movementSpeed * Time.deltaTime;

        if (horizontalInput != 0.0f)
        {
            float scaleX = horizontalInput < 0.0f ? -initScale.x : initScale.x;

            transform.localScale = new Vector3(scaleX, initScale.y, initScale.z);


        }

        playerAnim.SetBool("isRunning", horizontalInput != 0.0f);


        transform.Translate(new Vector3(horizontalMovement, 0.0f, 0.0f));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
            playerAnim.SetBool("isGrounded", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGER COLLISION WITH: " + collision.gameObject.name);
        if (collision.gameObject.tag == "FallPit")
        {
            transform.localPosition = initPos;
            isJumping = false;
            playerAnim.SetBool("isGrounded", true);
        }
    }
}
