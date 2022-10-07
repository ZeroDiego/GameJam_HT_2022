using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam : MonoBehaviour
{
    private JamSpawner spawner;
    public int jamValue;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<JamSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        StartCoroutine(TakeJam());
	}

    private IEnumerator TakeJam()
    {
        gameObject.SetActive(false);

        yield return new WaitForSeconds(3);
        spawner.SetJamPosition(gameObject);
    }
}
