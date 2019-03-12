using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanCrush : MonoBehaviour
{
    public bool canCrush = true;

    public void OnCollisionEnter(Collision col){
        //Debug.Log("Collided with "+col.gameObject.name);
        if(canCrush && col.gameObject.tag.Equals("Player")){
            CanDie playerCanDie = col.gameObject.GetComponent<CanDie>();
            playerCanDie.tryKillThySelf();
        } else if(canCrush && col.gameObject.tag.Equals("Ground")){
            canCrush = false;
        }
    }
}
