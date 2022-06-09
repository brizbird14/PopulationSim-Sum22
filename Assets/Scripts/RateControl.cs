using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateControl : MonoBehaviour
{
    // Growth rates of C - chicken, F - fox, M - mushroom
    float dCdt, dFdt, dMdt;
    [SerializeField] SpawnControl spawn;

    // CONSTANTS for Growth and Death such that:
    /*
        dC/dt = (cGrowth)(C) - (fGrowth)(C)(F)
        dF/dt = (fGrowth)(C)(F) - (mGrowth)(F)
        dM/dt = (mGrowth)(F) - (mDeath)(M)
        -- where (C) is chicken population, (F) is fox, and (M) is mushroom
        -- cGrowth = fGrowth and fDeath = mGrowth, only M dies indep. b/c no predator
    */
    // NOTE: cGrowth controlled by EnviroControl (user input)
    [SerializeField] cGrowth, fGrowth, mGrowth, mDeath;

    void FixedUpdate() {
        
    }

    void CalcDC(float chickPop, float foxPop) {
        // Passed back to spawn
        dCdt =
    }
}
