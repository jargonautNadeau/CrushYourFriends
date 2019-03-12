using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CanDie : MonoBehaviour
{
    public float depthBeforeDeath = -4.0f;
    public int numLives = 1;

    public Action isDead;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= depthBeforeDeath){
            tryKillThySelf();
        }
    }
    public void tryKillThySelf() {
        if(numLives > 1) {
            //Lose a life
            gameObject.SetActive(false);
        } else if (numLives <= 1) {
            // Death insues
            //RoundManager.KillPlayer(gameObject);
            isDead();
            Destroy(gameObject);
            
        }
    }
    public void RespawnPlayer(Vector3 respawnPos) {
        numLives -= 1;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        Debug.Log("RespawningSelf at: "+respawnPos);
        gameObject.SetActive(true);
        rb.MovePosition(respawnPos);
        
    }
}
