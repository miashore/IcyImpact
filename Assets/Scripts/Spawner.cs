using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public Transform[] spawnPoints;
    public GameObject[] hazards;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public float minTimeBetweenSpawns;
    public float decrease;

    private float minSize = .3f;
    private float maxSize = .45f;

    public GameObject player;

    // Update is called once per frame
    void Update () {
        if (player != null) {
            if (timeBtwSpawns <= 0) {
                // spawn random hazard at random spawn point with random scaling
                Transform randomSpawnPoint = spawnPoints[Random.Range (0, spawnPoints.Length)];
                GameObject randomHazard = hazards[Random.Range (0, hazards.Length)];

                float randomFloat = Random.Range (minSize, maxSize);
                GameObject hazard = Instantiate (randomHazard, randomSpawnPoint.position, Quaternion.identity); // Quaternion.identity means no particular rotation
                Vector3 randomSize = new Vector3 (randomFloat, randomFloat, randomFloat);
                hazard.transform.localScale = randomSize;

                float randomPos = Random.Range (-25, 25);
                hazard.transform.rotation = Quaternion.Euler (randomPos, randomPos, 5);

                if (startTimeBtwSpawns > minTimeBetweenSpawns) {
                    startTimeBtwSpawns -= decrease;
                }

                timeBtwSpawns = startTimeBtwSpawns;
            } else {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}