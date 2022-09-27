using UnityEngine;

public class camscript : MonoBehaviour
{
    [SerializeField]
    Transform playerpos;
    [SerializeField]
    Vector3 offset;
    Vector3 dpos;
    [SerializeField]
    float dampspeed=0.125f;

    void FixedUpdate()
    {
        dpos.x=Mathf.Clamp(playerpos.position.x,-1f,Mathf.Infinity)+offset.x;
        dpos.y=Mathf.Clamp(playerpos.position.y,-3f,2f)+offset.y;
        dpos.z=-10;
        transform.position=Vector3.Lerp(transform.position,dpos,dampspeed);
    }
}
