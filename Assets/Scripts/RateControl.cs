using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateControl : MonoBehaviour
{
    // Growth rates of C - chicken, F - fox, M - mushroom
    float dCdt, dFdt, dMdt;
    [SerializeField] SpawnControl spawn;
    int cPop, fPop, mPop;

    // CONSTANTS for Growth and Death such that:
    /*
        dC/dt = (cGrowth)(C) - (fGrowth)(C)(F)
        dF/dt = (fGrowth)(C)(F) - (mGrowth)(F)
        dM/dt = (mGrowth)(F) - (mDeath)(M)
        -- where (C) is chicken population, (F) is fox, and (M) is mushroom
        -- cGrowth = fGrowth and fDeath = mGrowth, only M dies indep. b/c no predator
    */
    // NOTE: cGrowth controlled by EnviroControl (user input)
    [SerializeField] float cGrowth, fGrowth, mGrowth, mDeath;

    void FixedUpdate() {
        // Edit >> Project Settings >> Time -- Fixed time step set to 1 sec.
        // Calculate the growth rate
        mPop = spawn.ReturnPopSize(1);
        cPop = spawn.ReturnPopSize(2);
        fPop = spawn.ReturnPopSize(3);

        // Update population size, floor to last integer
        spawn.UpdatePopSize(1, CalcDM(fPop, mPop));
        spawn.UpdatePopSize(2, CalcDC(cPop, fPop));
        spawn.UpdatePopSize(3, CalcDF(cPop, fPop));

        // If d_/dt is pos, spawn; else, despawn -- for each population
        spawn.SpawnDespawn(1, CalcDM(fPop, mPop));
        spawn.SpawnDespawn(2, CalcDC(cPop, fPop));
        spawn.SpawnDespawn(3, CalcDF(cPop, fPop));
    }

    public void UpdateCGrowth(float lightVal, bool pond) {
        // Update cGrowth based on environmental factors
        // lightVal multiplier of 50, +20 if pond on
        cGrowth = (lightVal * 50.0f);
        if (pond) {
            cGrowth += 20.0f;
        }
    }

    int CalcDC(int chickPop, int foxPop) {
        // Passed back to spawn
        dCdt = (cGrowth * chickPop) - (fGrowth * chickPop * foxPop);
        return Mathf.FloorToInt(dCdt);
    }
    int CalcDF(int chickPop, int foxPop) {
        dFdt = (fGrowth * chickPop * foxPop) - (mGrowth * foxPop);
        return Mathf.FloorToInt(dFdt);
    }
    int CalcDM(int foxPop, int mushPop) {
        dMdt = (mGrowth * foxPop) - (mDeath * mushPop);
        return Mathf.FloorToInt(dMdt);
    }
}
