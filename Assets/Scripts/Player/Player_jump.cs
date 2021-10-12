using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_jump : MonoBehaviour
{
    private int collisionCount;
    private bool jump;
    public Transform playerBody;
    private Rigidbody player;
    // Start is called before the first frame update
    void Start()
    {
        collisionCount=0;
        player=playerBody.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jump=Input.GetButton("Jump");
    }

    void OnCollisionEnter(Collision collision)
    {
        collisionCount++;
    }

    void OnCollisionExit(Collision collision)
    {
        collisionCount--;
    }

     void FixedUpdate()
    {
        //jump
        if(jump && player.velocity.y==0){player.AddForce(Vector3.up*250);}
    }
}
