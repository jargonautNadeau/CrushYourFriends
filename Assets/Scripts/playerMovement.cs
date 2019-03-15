using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Movement movement;


    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    private bool attacking = false;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        movement = new Movement();
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
            // Make it move 10 meters per second instead of 10 meters per frame...
            Vector3 rotation = movement.CalculateRotation(Input.GetAxis("Horizontal"),rotationSpeed,Time.deltaTime);
            Vector3 translation = movement.CalculatePosition(Input.GetAxis("Vertical"),speed,Time.deltaTime);
            // Move translation along the object's z-axis
            transform.Translate(translation);
            // Rotate around our y-axis
            transform.Rotate(rotation);
            
            if(translation.magnitude == 0f && rotation.magnitude == 0f){
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
