using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointscript : MonoBehaviour
{
    Animator ani;
    
    void Start()
    {
        ani=GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ani.SetTrigger("check");
    }
}
