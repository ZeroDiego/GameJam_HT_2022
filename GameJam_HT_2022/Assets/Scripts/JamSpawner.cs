using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamSpawner : MonoBehaviour
{
    [SerializeField] private GameObject jamObject;
    [SerializeField] private Vector2 area;
    [SerializeField]private float x = 8;
    [SerializeField]private float y = 4;

    private void Start()
	{
        x *= Screen.width;
        x /= 1920;

        y *= Screen.height;
        y /= 1080;

        SpawnJam();
        
    }

	public void SpawnJam()
    {
        Instantiate(jamObject, transform);
    }

    public void DisableJam(GameObject gO)
    {
        StartCoroutine(TakeJam(gO));
    }

    public IEnumerator TakeJam(GameObject gO)
    {
        gO.SetActive(false);
        yield return new WaitForSeconds(1);
        SetJamPosition(gO);
    }

    public void SetJamPosition(GameObject spawnedJam)
    {
        spawnedJam.SetActive(true);
        spawnedJam.transform.position = new Vector2(Random.Range(-x, x), Random.Range(-y, y));
        //spawnedJam changes position
    }
}
