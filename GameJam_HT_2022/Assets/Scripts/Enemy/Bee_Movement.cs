using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public Transform target;

    public float moveSpeed = 1f;
    private bool isFacingRight;
    private bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }

        if(isFacingRight == true)
        {
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }
    }

    private void FixedUpdate()
    {
        if(isAlive == true)
        {
            if(target == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

                if(target.position.x - transform.position.x < 0)
                {
                    isFacingRight = true;
                }
                else
                {
                    isFacingRight = false;
                }
            }
        }
    }
}
