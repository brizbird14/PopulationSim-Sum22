using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphControl : MonoBehaviour
{
    [SerializeField] GameObject rateMarker;
    [SerializeField] SpawnControl spawn;
    // Keeping C axis within x = -0.235f (LEFT) to x = 0.05f (RIGHT)
    // Keeping F axis within y = -0.14f (BOT) to y = 0.18f (TOP)

    int cPop, fPop;
    float newX, newY;

    [SerializeField] float xMin, xMax, yMin, yMax, zCoord; // coords, to avoid hard-coding

    bool waitUpdate;

    void Start()
    {
        rateMarker.transform.localPosition = new Vector3(xMin, yMin, zCoord);
        waitUpdate = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!waitUpdate) {
            waitUpdate = true;
            return;
        }

        cPop = spawn.ReturnPopSize(2);
        fPop = spawn.ReturnPopSize(3);

        // MAX 100
        // Divide diff between min and max by 100 for coord diff. for ea. C or F

        // move C
        if (cPop < 0) {
            newX = xMin;
        } else if (cPop > 100) {
            newX = xMax;
        } else {
            newX = xMin + (xMax - xMin)*cPop/100;
        }
        // move F
        if (fPop < 0) {
            newY = yMin;
        } else if (fPop > 100) {
            newY = yMax;
        } else {
            newY = yMin + (yMax - yMin)*fPop/100;
        }
        rateMarker.transform.localPosition = new Vector3(newX, newY, zCoord);
    }
}
