using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiavateHitEffect : MonoBehaviour
{
    public float timer = 2f;
    void Start() {
        Invoke("deactiavateHitEffect",timer);
    }
    void deactiavateHitEffect(){
        gameObject.SetActive(false);
    }
}
