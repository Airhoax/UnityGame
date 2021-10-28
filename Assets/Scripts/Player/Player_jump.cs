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

    void OnTriggerEnter(Collider collision)
    {
        if(GameObject.Find(collision.name).transform.parent.name!="Player Hand"){collisionCount++;}
    }

    void OnTriggerExit(Collider collision)
    {
        if(GameObject.Find(collision.name).transform.parent.name!="Player Hand"){collisionCount--;}
    }

     void FixedUpdate()
    {
        //jump
        if(jump && collisionCount>0){player.AddForce(Vector3.up*100);}
    }
}
