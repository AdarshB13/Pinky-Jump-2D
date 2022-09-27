using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinkyscript : MonoBehaviour
{
    Vector3 nint;
    Rigidbody2D rbp;
    [SerializeField]
    float speed,maxspeed,jumphieght;
    Animator ani;
    [SerializeField]
    int jc,ja;
    [SerializeField]
    bool onground;
    SpriteRenderer sprite;

    void Start()
    {
        rbp=GetComponent<Rigidbody2D>();
        ani=GetComponent<Animator>();
        sprite=GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(onground||jc<2)
        {
            if(onground && jc==0)
            {
                jc=1;
            }
            if(onground && jc>1)
            {
                jc=0;
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rbp.AddForce(new Vector2(0,1)*jumphieght);
                if(ja==0)
                {
                    ani.SetTrigger("jump");
                    ja+=1;
                }
                else if(ja==1)
                {
                    ani.SetTrigger("doublejump");
                    ja=0;
                }
                jc+=1;
            }
        }
        if(rbp.velocity.magnitude<maxspeed)
        {
            if(Input.GetKey(KeyCode.D))
            {
                nint.x=1f;
                sprite.flipX=false;
                ani.SetBool("run",true);
            }
            if(Input.GetKey(KeyCode.A))
            {
                nint.x=-1f;
                sprite.flipX=true;
                ani.SetBool("run",true);
            }
        }
        else
        {
            nint.x=0;
            ani.SetBool("run",false);
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        rbp.AddForce(nint*speed);
        RaycastHit2D hit=Physics2D.Raycast(new (transform.position.x,transform.position.y-0.9f),new (transform.position.x,transform.position.y-2.8f),0.5f);
        if(hit.collider!=null)
        {
            onground=true;
            ani.SetBool("onground",true);
        }
        else
        {
            onground=false;
            ani.SetBool("onground",false);
        }
        //Debug.DrawLine(new (transform.position.x,transform.position.y-0.9f),new (transform.position.x,transform.position.y-0.5f),Color.black);
    }

    public bool pinkydir()
    {
        if(sprite.flipX==false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
