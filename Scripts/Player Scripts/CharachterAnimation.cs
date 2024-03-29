using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CharachterAnimation : MonoBehaviour
{
    private Animator anim;

    void Awake(){

        anim = GetComponent<Animator>();
    }
    public void Walk(bool move){
        anim.SetBool("Movement",move);
    }
    public void Punch1(){
        anim.SetTrigger("Punch1");
    }
    public void Punch2(){
        anim.SetTrigger("Punch2");
    }
    public void Punch3(){
        anim.SetTrigger("Punch3");
    }
    public void Kick1(){
        anim.SetTrigger("Kick1");
    }
    public void Kick2(){
        anim.SetTrigger("Kick2");
    }
    public void Death(){
        anim.SetTrigger("Death");
    }

}//end












