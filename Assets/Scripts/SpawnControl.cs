using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class SpawnControl : MonoBehaviour
{
    [SerializeField] GameObject mobShroom, mobChick, mobFox;
    float spawnX, spawnZ;

    // Spawn rates, will b controlled by script eventually

    // Spawn locations, manual input in editor
    //[SerializeField] float shroomX, shroomZ;
    //[SerializeField] float chickX, chickZ;
    //[SerializeField] float foxX, foxZ;

    // Number of things, tracked at spawn and used to calc rates
    [SerializeField] int numShroom, numChick, numFox;

    // Growth rate of things (i.e. how many to spawn each second)
    int growthShroom, growthChick, growthFox;

    [SerializeField] float spawnerWait;

    [SerializeField] RateControl rateController; // ONLY ref when turning on in beginning

    bool spawnPaused;

    void Start() {
        // Start each population at 3
        numShroom = 24;
        numChick = 45;
        numFox = 48;

        for (int x = 0; x < 3; x++) {
            Instantiate(mobChick, new Vector3(Random.Range(-3.5f, 3.5f), -0.53f, Random.Range(-3.17f, -6.0f)), Quaternion.identity);
            Instantiate(mobFox, new Vector3(Random.Range(-3.5f, 3.5f), -0.34f, Random.Range(-3.17f, -6.0f)), Quaternion.identity);
            Instantiate(mobShroom, new Vector3(Random.Range(-3.5f, 3.5f), -0.6f, Random.Range(-3.17f, -6.0f)), Quaternion.identity);
        }

        StartCoroutine(WaitRateController());
    }

    IEnumerator WaitRateController() {
        yield return new WaitForSeconds(1.0f);
        rateController.enabled = true;
    }

    //FOR TESTING SPAWN AND DESPAWN
    void Update() {
        #if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.S)) {
                //Spawn
                StartCoroutine(SpawnDespawnCoroutine(3, 2));
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                //Despawn
                StartCoroutine(SpawnDespawnCoroutine(3, -2));
            }
        #endif
    }

    public void UpdatePopSize(int mob, int growthRate) {
        // Updates current population size of each mob
        // Called by RateControl script based on growth rate
        switch (mob) {
            case 1:
                growthShroom = growthRate;
                numShroom += growthRate;
                break;
            case 2:
                //Debug.Log("Chicken GR " + growthRate);
                growthChick = growthRate;
                numChick += growthRate;
                break;
            case 3:
                growthFox = growthRate;
                numFox += growthRate;
                break;
        }
        SpawnDespawn(mob, growthRate);
    }

    public int ReturnPopSize(int mob) {
        // Returns current population size of each mob
        // Called by RateControl script to calc growth rates
        switch (mob) {
            case 1:
                return numShroom;
            case 2:
                return numChick;
            case 3:
                return numFox;
        }
        Debug.Log("ERROR: Requested pop. size of unknown mob");
        return 0;
    }

    public void SpawnDespawn(int mob, int popIncr) {
        if (!spawnPaused) {
            StartCoroutine(SpawnDespawnCoroutine(mob, popIncr));
        }
    }

    public Tuple<float, float> generateCoords() {
        float spawnX = Random.Range(-3.5f, 3.5f);
        float spawnZ = 0.0f;
        if (spawnX < 0.2f) { // if spawn within pond's x, bound, ensure not within z bound
            spawnZ = Random.Range(-3.17f, -6.0f);
        } else { // otherwise spawn wherever, larger Z range
            spawnZ = Random.Range(-0.5f, -6.0f);
        }
        return Tuple.Create(spawnX, spawnZ);
    }

    IEnumerator SpawnDespawnCoroutine(int mob, int popIncr) {
        //Debug.Log("Coroutine reached");
        switch(mob) {
            case 1:
                if (popIncr >= 0) {
                    for (int i = 0; i < popIncr; i++) {
                        if (spawnPaused) break;
                        (spawnX, spawnZ) = generateCoords();
                        Instantiate(mobShroom, new Vector3(spawnX, -0.6f, spawnZ), Quaternion.identity);
                        yield return new WaitForSeconds(spawnerWait);
                    }
                } else { // population is decreasing
                    for (int j = 0; j > popIncr; j--) {
                        if (spawnPaused) break;
                        Destroy(GameObject.FindWithTag("MobShroom"));
                        yield return new WaitForSeconds(spawnerWait);
                    }
                }
                break;
            case 2:
                if (popIncr >= 0) {
                    for (int i = 0; i < popIncr; i++) {
                        if (spawnPaused) break;
                        (spawnX, spawnZ) = generateCoords();
                        Instantiate(mobChick, new Vector3(spawnX, -0.53f, spawnZ), Quaternion.identity);
                        yield return new WaitForSeconds(spawnerWait);
                    }
                } else { // population is decreasing
                    for (int j = 0; j > popIncr; j--) {
                        if (spawnPaused) break;
                        Destroy(GameObject.FindWithTag("MobChick"));
                        yield return new WaitForSeconds(spawnerWait);
                    }
                }
                break;
            case 3:
                if (popIncr >= 0) {
                    for (int i = 0; i < popIncr; i++) {
                        if (spawnPaused) break;
                        (spawnX, spawnZ) = generateCoords();
                        Instantiate(mobFox, new Vector3(spawnX, -0.34f, spawnZ), Quaternion.identity);
                        yield return new WaitForSeconds(spawnerWait);
                    }
                } else { // population is decreasing
                    for (int j = 0; j > popIncr; j--) {
                        if (spawnPaused) break;
                        Destroy(GameObject.FindWithTag("MobFox"));
                        yield return new WaitForSeconds(spawnerWait);
                    }
                }
                break;
        }
        if (spawnPaused) yield break;
    }

    public void PlaySpawn (bool pause) {
        spawnPaused = pause;
    }
}
