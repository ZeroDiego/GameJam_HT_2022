using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam : MonoBehaviour
{
    public int jamValue;
    private JamSpawner spawner;

    void Start()
    {
        spawner = GetComponentInParent<JamSpawner>();
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerResource.Instance.EatJam(jamValue);
            spawner.DisableJam(gameObject);
        }

        if(collision.gameObject.CompareTag("Spider"))
        {
            spawner.DisableJam(gameObject);
        }
	}
}
