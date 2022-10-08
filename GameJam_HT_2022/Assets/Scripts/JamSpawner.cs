using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamSpawner : MonoBehaviour
{
    [SerializeField] private GameObject jamObject;
    [SerializeField] private float x = 0;
    [SerializeField] private float y = 0;
    [SerializeField] private int spawnSecondJam = 15;
    [SerializeField] private int spawnThirdJam = 40;

    private void Start()
	{
        x = Camera.main.aspect + 5;
        y = Camera.main.aspect + 2;
        StartGame();
    }

    public void StartGame()
    {
        while (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0));
        }
        SpawnJam();
        Invoke(nameof(SpawnJam), spawnSecondJam);
        Invoke(nameof(SpawnJam), spawnThirdJam);
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
    }
}
