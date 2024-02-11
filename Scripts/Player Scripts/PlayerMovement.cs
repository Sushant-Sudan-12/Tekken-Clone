using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody mybody;
    private CharachterAnimation player_anim;

    private float x_speed = 3f;
    private float z_speed = 2f;

    private float rotation_y = -90f;
    private float rotation_speed = 15f;

    void Awake()
    {
        mybody = GetComponent<Rigidbody>();
        player_anim = GetComponentInChildren<CharachterAnimation>();
    }


    void Start()
    {
        
    }
    void Update()
    {
        rotatePlayer();
        AnimateWalk();
    }

    void FixedUpdate()
    {
        dectectMovement();
    }

    void dectectMovement(){
        mybody.velocity = new Vector3(
            Input.GetAxisRaw("Horizontal")*-x_speed,
            mybody.velocity.y,
            Input.GetAxisRaw("Vertical")*-z_speed
        );
    }

    void rotatePlayer(){
        if(Input.GetAxisRaw("Horizontal")>0){
            transform.rotation =  Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(0f,rotation_y,0f),rotation_speed);
        }else if(Input.GetAxisRaw("Horizontal")<0){
            transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.Euler(0f,Mathf.Abs(rotation_y),0f),rotation_speed);

        }
    }

    void AnimateWalk(){
        if(Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical")!=0){
            player_anim.Walk(true);
        }else{
            player_anim.Walk(false);
        }
    } 

    


}//end











