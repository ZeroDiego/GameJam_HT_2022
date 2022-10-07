using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Movement : MonoBehaviour
{

    public Transform target;

    public float moveSpeed = 1f;
    public float rotationSpeed = 4f;
    private bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (isAlive == true)
        {
            if (target == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }
        }
    }
}
