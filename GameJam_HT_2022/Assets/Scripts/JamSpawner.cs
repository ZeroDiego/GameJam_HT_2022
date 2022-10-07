using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamSpawner : MonoBehaviour
{
    [SerializeField] private GameObject jamObject;

	private void Start()
	{
        SpawnJam();
	}

	public void SpawnJam()
    {
        Instantiate(jamObject, transform);
    }

    public IEnumerator TakeJam()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        SetJamPosition(gameObject);
    }

    public void SetJamPosition(GameObject spawnedJam)
    {
        transform.position = new Vector2(Random.Range(-25, 26), Random.Range(-25, 26));
        //spawnedJam changes position
    }
}
