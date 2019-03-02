using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpTakeOffSpeed;
    private float inputHorizontal;
    private float inputVertical;
    public float distance;

    private Rigidbody2D rb;
    public LayerMask ladderLayer;

    private bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        inputHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpTakeOffSpeed);
        }

        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, ladderLayer);

        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
            }
        }
        else
        {
            isClimbing = false;
        }

        if (isClimbing == true)
        {
            inputVertical = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 5;
        }
    }
}
