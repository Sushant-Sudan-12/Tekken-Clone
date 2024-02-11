using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState {
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2

}

public class PlayerAttacks : MonoBehaviour
{

    private CharachterAnimation player_anim;

    private float default_combo_timer=0.4f;
    private float current_combo_timer;
    private bool activateTimertoReset ;

    private ComboState current_combo_state;

    void Awake(){

        player_anim = GetComponentInChildren<CharachterAnimation>();
        current_combo_timer = default_combo_timer;
        current_combo_state = ComboState.NONE;

    
    }
    void Start()
    {

    }

    void Update()
    {
        comboAttack();
        resetState();
    }

    void comboAttack(){
        if(Input.GetKeyDown(KeyCode.X)){
            current_combo_state++;
            activateTimertoReset = true;

            if(current_combo_state == ComboState.PUNCH_1){
                player_anim.Punch1();
            }
            if(current_combo_state == ComboState.PUNCH_2){
                player_anim.Punch2();
            }
            if(current_combo_state == ComboState.PUNCH_3){
                player_anim.Punch3();
            }
        }
    }

    void resetState(){
        if(activateTimertoReset){
            current_combo_timer-=Time.deltaTime;
            if(current_combo_timer<=0f){
                current_combo_state = ComboState.NONE;

                activateTimertoReset= false;
                current_combo_timer=default_combo_timer;
            }
        }
    }






}//end





