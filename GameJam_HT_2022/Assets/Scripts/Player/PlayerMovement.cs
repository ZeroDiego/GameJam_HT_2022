using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;

    private float horizontal;
    private float vertical;
    [SerializeField] public float moveLimiter = 0.7f;

    [SerializeField] public float runSpeed = 20.0f;
    [SerializeField] public GameObject spitObject;
    [SerializeField] public Transform firePoint;
    private static PlayerMovement instance;
    public PlayerMovement Instance { get { return instance; } set { instance = value; } }

    private void Awake()
	{
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
	}

	void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        RotateAfterMouse();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

	private void Shoot()
	{
        GameObject spit = null;
        foreach (Transform t in GetComponentInChildren<Transform>())
        {
            if (!t.gameObject.activeSelf && GetComponentInChildren<Spit>(true))
            {
                spit = t.gameObject;
                break;
            }
        }
        if (spit == null)
        {
            spit = Instantiate(spitObject);
        }
        else
        {
            spit.SetActive(true);
            spit.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);
        }
        spit.GetComponent<Spit>().Shot(firePoint);

	}

	private void RotateAfterMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, runSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
