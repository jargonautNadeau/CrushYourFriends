﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    private bool attacking = false;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && !attacking){
            //Debug.Log("Start Attacking");
            attacking = true;
            anim.SetBool("isAttacking",true);
            StartCoroutine("AttackRoutine");
        }
        
        if(!attacking) {
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            // Make it move 10 meters per second instead of 10 meters per frame...
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            // Move translation along the object's z-axis
            transform.Translate(0, 0, translation);
            // Rotate around our y-axis
            transform.Rotate(0, rotation, 0);
            if(translation == 0 && rotation == 0){
                anim.SetBool("isWalking",false);
            } else {
                anim.SetBool("isWalking",true);
            }
        }
    }

    IEnumerator AttackRoutine () {
        //Debug.Log("Middle Attacking");
        yield return new WaitForSeconds(2.2f);
        attacking = false;
        anim.SetBool("isAttacking",false);
        //Debug.Log("End Attacking");
    }
}
