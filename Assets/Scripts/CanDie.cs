using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanDie : MonoBehaviour
{
    public float depthBeforeDeath = -4.0f;
    public int numLives = 1;

    public delegate void playerDiedDelegate ();
	public playerDiedDelegate isDead;
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
            Vector3 spawnLoc = new Vector3(3,1,10);
            RespawnPlayer(spawnLoc);
        } else if (numLives <= 1) {
            // Death insues
            //RoundManager.KillPlayer(gameObject);
            isDead();
            Destroy(gameObject);
            
        }
    }
    void RespawnPlayer(Vector3 respawnPos) {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.MovePosition(respawnPos);
    }
}
