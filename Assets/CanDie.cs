using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanDie : MonoBehaviour
{
    public float depthBeforeDeath = -4.0f;
    public int numLives = 1;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= depthBeforeDeath){
            tryKillThySelf();
        }
    }
    void tryKillThySelf() {
        if(numLives > 1) {
            //Lose a life
            numLives -= 1;
            RespawnPlayer();
        } else if (numLives <= 1) {
            // Death insues
            //RoundManager.KillPlayer(gameObject);

        }
    }
    void RespawnPlayer() {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.MovePosition(new Vector3(0,0,0));
    }
}
