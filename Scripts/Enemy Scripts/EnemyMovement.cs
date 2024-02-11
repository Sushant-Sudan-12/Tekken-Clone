using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    private CharachterAnimation enemy_anim;
    private Rigidbody mybody;

    private bool follow_player,attack_player;

    public float speed = 2f;

    public float attack_distance = 1.5f;
    private float follow_player_after_attack = 1f;
    public Transform player_body;

    private float current_attack_timer ;
    public float default_attack_timer = 1.5f;

    void Awake()
    {
        enemy_anim = GetComponentInChildren<CharachterAnimation>(); 
        mybody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        follow_player = true;
        current_attack_timer = default_attack_timer;
    }


    void Update()
    {
        AttackPlayer();
    }

    void FixedUpdate()
    {
        followPlayer();
    }
    
    void followPlayer(){
        if(!follow_player){
            return;
        }
        if(Vector3.Distance(transform.position,player_body.position) > attack_distance){
            transform.LookAt(player_body);
            mybody.velocity = transform.forward*speed;
            if(mybody.velocity.sqrMagnitude!=0){
                enemy_anim.Walk(true);
            }
        }else if(Vector3.Distance(transform.position,player_body.position)<=attack_distance){
            mybody.velocity = Vector3.zero;
            enemy_anim.Walk(false);
            follow_player = false;
            attack_player = true;
        }
    }
    void AttackPlayer(){

        if(!attack_player){
            return;
        }
        current_attack_timer += Time.deltaTime;
        if(current_attack_timer > default_attack_timer){
            enemy_anim.Attack(Random.Range(1,3));
            current_attack_timer = 0f;
        }
        if(Vector3.Distance(transform.position,player_body.position)>attack_distance+follow_player_after_attack){
            attack_player = false;
            follow_player = true;
        }
         
    }

    




}//end












