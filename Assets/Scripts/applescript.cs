using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applescript : MonoBehaviour
{
    Animator ani;

    void Start()
    {
        ani=GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name=="pinky")
        {
            ani.SetTrigger("eat");
            GetComponent<Collider2D>().enabled=false;
        }
    }

    void todestroy()
    {
        Destroy(gameObject);
    }
}
