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
