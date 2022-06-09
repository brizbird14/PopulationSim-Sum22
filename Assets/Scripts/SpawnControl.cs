using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    GameObject mobShroom;

    // Spawn rates, will b controlled by script eventually

    // Spawn locations, manual input in editor
    [SerializeField] float shroomX, shroomZ;
    [SerializeField] float chickX, chickZ;
    [SerializeField] float foxX, foxZ;

    // Number of things, tracked at spawn and used to calc rates
    int numShroom, numChick, numFox;

    void Start() {
        // Start each population at size 0
        numShroom = 0;
        numChick = 0;
        numFox = 0;
    }

    public void UpdatePopSize(int mob, int newSize) {
        // Updates current population size of each mob
        // Called by RateControl script based on growth rate
        switch (mob) {
            case 1:
                numShroom = newSize;
                break;
            case 2:
                numChick = newSize;
                break;
            case 3:
                numFox = newSize;
                break;
        }
    }

    public int ReturnPopSize(int mob) {
        // Returns current population size of each mob
        // Called by RateControl script to calc growth rates
        switch (mob) {
            case 1:
                return numShroom;
                break;
            case 2:
                return numChick;
                break;
            case 3:
                return numFox;
                break;
        }
        Debug.Log("ERROR: Requested pop. size of unknown mob");
        return 0;
    }
}
