using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam : MonoBehaviour
{
    public int jamValue;
    private JamSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponentInParent<JamSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            spawner.DisableJam(gameObject);
        }
	}
}
