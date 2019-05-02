using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform wallDetection;

    private Animator enemyAnimator;

    public float speed;
    public float rayDistance;

    private bool movingDirection = true;    //true - right, false - left


    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D raycastInfo;

        if (movingDirection)
        {
            raycastInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, rayDistance);
        }
        else
        {
            raycastInfo = Physics2D.Raycast(wallDetection.position, Vector2.left, rayDistance);
        }

        if (raycastInfo.collider && enemyAnimator.GetBool("isInEnemyZone") == false)
        {
            if (movingDirection)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingDirection = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingDirection = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemyAnimator.SetBool("isInEnemyZone", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemyAnimator.SetBool("isInEnemyZone", false);
        }
    }
}
