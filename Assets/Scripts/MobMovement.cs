using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{

    [SerializeField] float mobSpeed; // Speed multiplier
    bool turnStop; // When true, suspends movement while turning
    float timeToTurn; // When next change of direction
    float moveDirec; // Randomizes movement direction

    void Start() {
        ChangeDirection();
        timeToTurn = Time.time + Random.Range(1.5f, 5.0f);
        turnStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToTurn) {
            ChangeDirection();
            timeToTurn = Time.time + Random.Range(1.5f, 5.0f);
        }

        if (turnStop) {
            //Debug.Log("Stopping");
            this.gameObject.transform.position = this.gameObject.transform.position;
        } else if (moveDirec < 1.0f) {
            this.gameObject.transform.position += this.gameObject.transform.up * Time.deltaTime * mobSpeed;
        } else if (moveDirec < 2.0f) {
            this.gameObject.transform.position -= this.gameObject.transform.up * Time.deltaTime * mobSpeed;
        } else if (moveDirec < 3.0f) {
            this.gameObject.transform.position += this.gameObject.transform.right * Time.deltaTime * mobSpeed;
        } else {
            this.gameObject.transform.position -= this.gameObject.transform.right * Time.deltaTime * mobSpeed;
        }
    }

    void ChangeDirection () {
        //Debug.Log("Changing direction");
        moveDirec = Random.Range(0.0f, 4.0f);
    }

    void OnCollisionEnter (Collision col) {
        // Upon hitting walls
        turnStop = true;
        if (col.gameObject.tag == "Environment") {
            //Debug.Log("Hit wall");
            // Rotate away from wall
            this.gameObject.transform.Rotate(0.0f, Random.Range(-100.0f, 100.0f), 0.0f, Space.Self);
        }
    }
}
