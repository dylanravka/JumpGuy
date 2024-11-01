using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject[] collectibles;

    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < collectibles.Length; i++)
        {
            int randomCollectibleNum = Random.Range(0, collectibles.Length);
            int randomSpawnPointNum = Random.Range(0, spawnPoints.Length);

            Instantiate(collectibles[randomCollectibleNum], spawnPoints[randomSpawnPointNum].position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
