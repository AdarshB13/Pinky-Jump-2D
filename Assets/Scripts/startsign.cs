using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startsign : MonoBehaviour
{
    Animator ani;
    pinkyscript pinkycon;
    float delay=2f;
    bool start=true;

    void Start()
    {
        ani=GetComponent<Animator>();
    }

    void FixedUpdate()
    {   
        if(delay>0)
        {
            delay-=Time.deltaTime;
            if(delay<0)
            {
                start=true;
            }  
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name=="pinky" && start)
        {
            pinkycon=other.GetComponent<pinkyscript>();
            if(pinkycon.pinkydir())
            {
                ani.SetTrigger("start");
                start=false;
                delay=2f;
            }    
        }
    }
}
