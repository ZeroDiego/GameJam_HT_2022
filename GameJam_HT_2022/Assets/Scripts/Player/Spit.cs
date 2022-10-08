using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
	private Rigidbody2D rigidBody;
	[SerializeField] private float speed;
	public float damage;

	public void Awake()
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}

	public void Shot(Transform firepoint)
	{
		rigidBody.AddForce(firepoint.up * speed, ForceMode2D.Impulse);
	}

	private void OnBecameInvisible()
	{
		gameObject.SetActive(false);
	}
}
