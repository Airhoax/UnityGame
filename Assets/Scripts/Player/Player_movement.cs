using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{

    private Rigidbody player;
    private float horizontalInput;
    private float verticalInput;
    private float mousex;
    private float rotation;
    void Start()
    {
        //lock mouse
        Cursor.lockState =CursorLockMode.Locked;

        //set variables
        player=transform.GetComponent<Rigidbody>();
        mousex=0;
    }

    void Update()
    {
        //get inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        mousex+=Input.GetAxis("Mouse X")*Time.deltaTime*1000;
    }

    void FixedUpdate()
    {
        //look left/right
        player.MoveRotation(Quaternion.Euler(new Vector3(0, mousex,0)));

        //move player
        rotation=Mathf.Deg2Rad*transform.eulerAngles.y;
        Vector3 verticalVector = new Vector3(Mathf.Sin(rotation),0,Mathf.Cos(rotation))*verticalInput*10;
        Vector3 horizontalVector = new Vector3(Mathf.Sin(rotation+Mathf.PI/2),0,Mathf.Cos(rotation+Mathf.PI/2))*horizontalInput*10;
        player.velocity = new Vector3(0,player.velocity.y,0)+ horizontalVector + verticalVector;
    }
}
