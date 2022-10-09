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

    [SerializeField] private float runSpeed = 20.0f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private GameObject spitObject;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform spitList;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip spitClip;
    [SerializeField] private float timer;
    [SerializeField] private float shotCooldown = 0.2f;

    private static PlayerMovement instance;
    public static PlayerMovement Instance { get { return instance; } set { instance = value; } }

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
        timer = shotCooldown;
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        RotateAfterMouse();
        if (Input.GetMouseButton(0) && timer > shotCooldown)
        {
            Shoot();
        }
    }

	private void Shoot()
	{
        timer = 0;
        GameObject spit = null;
        audioSource.PlayOneShot(spitClip);
        foreach (Transform t in spitList)
        {
            if (t.gameObject.activeSelf == false)
            {
                spit = t.gameObject;
                break;
            }
        }
        if (spit == null)
        {
            spit = Instantiate(spitObject, spitList);
        }
        else
        {
            spit.transform.parent = transform;
            spit.SetActive(true);
        }
        spit.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);
        spit.GetComponent<Spit>().Shot(firePoint);
        spit.transform.parent = spitList;
    }

	private void RotateAfterMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
