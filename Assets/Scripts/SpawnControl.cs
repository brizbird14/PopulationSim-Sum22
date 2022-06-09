using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    [SerializeField] GameObject mobShroom, mobChick, mobFox;

    // Spawn rates, will b controlled by script eventually

    // Spawn locations, manual input in editor
    //[SerializeField] float shroomX, shroomZ;
    //[SerializeField] float chickX, chickZ;
    //[SerializeField] float foxX, foxZ;

    // Number of things, tracked at spawn and used to calc rates
    int numShroom, numChick, numFox;

    // Growth rate of things (i.e. how many to spawn each second)
    int growthShroom, growthChick, growthFox;

    [SerializeField] float spawnerWait;

    void Start() {
        // Start each population at size 0
        numShroom = 0;
        numChick = 0;
        numFox = 0;
    }

    //FOR TESTING SPAWN AND DESPAWN
    void Update() {
        #if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.S)) {
                //Spawn
                StartCoroutine(SpawnDespawnCoroutine(1, 2));
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                //Despawn
                StartCoroutine(SpawnDespawnCoroutine(1, -2));
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
                growthChick = growthRate;
                numChick += growthRate;
                break;
            case 3:
                growthFox = growthRate;
                numFox += growthRate;
                break;
        }
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
        StartCoroutine(SpawnDespawnCoroutine(mob, popIncr));
    }

    IEnumerator SpawnDespawnCoroutine(int mob, int popIncr) {
        switch(mob) {
            case 1:
                if (popIncr >= 0) {
                    for (int i = 0; i < popIncr; i++) {
                        Instantiate(mobShroom, new Vector3(Random.Range(-4.0f, 4.0f), -0.67f, Random.Range(-0.6f, -6.5f) ), Quaternion.identity);
                        yield return new WaitForSeconds(spawnerWait);
                    }
                } else { // population is decreasing
                    for (int j = 0; j > popIncr; j--) {
                        Destroy(GameObject.FindWithTag("MobShroom"));
                        yield return new WaitForSeconds(spawnerWait);
                    }
                }
                break;
        }
    }
}
