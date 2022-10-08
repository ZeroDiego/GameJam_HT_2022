using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
	private Rigidbody2D rigidbody;
	[SerializeField] private float speed;
	public float damage;

	public void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	public void Shot(Transform firepoint)
	{
		rigidbody.AddForce(firepoint.up * speed, ForceMode2D.Impulse);
	}

	private void OnBecameInvisible()
	{
		gameObject.SetActive(false);
	}
}
