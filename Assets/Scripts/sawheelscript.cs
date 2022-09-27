using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawheelscript : MonoBehaviour
{
    [SerializeField]
    float len,bre,speed;
    Vector3 a,b,c,d,despos;
    int stepoint;

    void Start()
    {
        a=transform.position;
        b.x=transform.position.x;
        b.y=transform.position.y+bre;
        c.x=transform.position.x+len;
        c.y=transform.position.y+bre;
        d.x=transform.position.x+len;
        d.y=transform.position.y;
        despos=a;
    }

    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position,despos)<0.1f)
        {
            stepoint+=1;
            if(stepoint==5)
            {
                stepoint=1;
            }
            step();
        }
        transform.position=Vector3.Lerp(transform.position,despos,speed);
    }

    void step()
    {
        if(stepoint==1)
        {
            despos=a;
        }
        if(stepoint==2)
        {
            despos=b;
        }
        if(stepoint==3)
        {
            despos=c;
        }
        if(stepoint==4)
        {
            despos=d;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
    }
}
