using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamSpawner : MonoBehaviour
{
    public int jamCount = 1;
    private List<GameObject> jamList = new List<GameObject>();
    private GameObject jamObject;

    public void AddJam()
    {
        jamList.Add(jamObject);
    }

    public void SpawnJam()
    {
        GameObject spawnedJam = null;
        foreach (GameObject j in jamList)
        {
            if (j.activeSelf)
            {
                spawnedJam = j;
            }
        }

        if (spawnedJam == null && jamCount < 1)
        {
            spawnedJam = Instantiate(jamObject);
            jamList.Add(spawnedJam);
        }

        spawnedJam.SetActive(true);
    }
}
