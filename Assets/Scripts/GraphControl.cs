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

    void Start()
    {
        rateMarker.transform.localPosition = new Vector3(-0.28f, -0.14f, -0.127f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("Graph is reached");
        cPop = spawn.ReturnPopSize(2);
        fPop = spawn.ReturnPopSize(3);

        // MAX 100
        // for x, width is 0.285 / 100 = 0.00285 per c
        // for y, height is 0.32 / 100 = 0.0032 per f

        // move C
        if (cPop < 0) {
            newX = -0.28f;
        } else if (cPop > 100) {
            newX = 0.05f;
        } else {
            newX = -0.028f + 0.00285f*cPop;
        }
        // move F
        if (fPop < 0) {
            newY = -0.14f;
        } else if (fPop > 100) {
            newY = 0.18f;
        } else {
            newY = -0.14f + 0.0032f*fPop;
        }
        rateMarker.transform.localPosition = new Vector3(newX, newY, -0.127f);
    }
}
