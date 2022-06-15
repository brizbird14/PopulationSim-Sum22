using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateControl : MonoBehaviour
{
    // Growth rates of C - chicken, F - fox, M - mushroom
    float dCdt, dFdt, dMdt;
    [SerializeField] SpawnControl spawn;
    [SerializeField] EnviroControl enviro; // Just for getting initials
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
    float cGrowth, fGrowth, mGrowth, mDeath;

    void OnEnable() {
        //Debug.Log("Is enabled");
        UpdateCGrowth(enviro.GetLightInitial(), enviro.GetPondInitial());
    }

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
        // in SpawnControl, UpdatePopSize() calls SpawnDespawn()
        // If d_/dt is pos, spawn; else, despawn -- for each population
    }

    public void UpdateCGrowth(float lightVal, bool pond) {
        // Update cGrowth based on environmental factors
        // lightVal multiplier of 50, +20 if pond on
        //Debug.Log("SETTING CGROWTH");
        //Debug.Log(lightVal);
        //Debug.Log(pond);
        cGrowth = (lightVal * 50.0f);
        if (pond) {
            cGrowth += 20.0f;
        }
        cGrowth = cGrowth / 10;

        // Update other coefs. to max at 50
        fGrowth = cGrowth/50;
        mGrowth = cGrowth;
        mDeath = cGrowth*2; // HMM
    }

    int CalcDC(int chickPop, int foxPop) {
        // Passed back to spawn
        dCdt = (cGrowth * chickPop) - (fGrowth * chickPop * foxPop);
        return Mathf.RoundToInt(dCdt);
    }
    int CalcDF(int chickPop, int foxPop) {
        dFdt = (fGrowth * chickPop * foxPop) - (mGrowth * foxPop);
        return Mathf.RoundToInt(dFdt);
    }
    int CalcDM(int foxPop, int mushPop) {
        dMdt = (mGrowth * foxPop) - (mDeath * mushPop);
        return Mathf.RoundToInt(dMdt);
    }
}
