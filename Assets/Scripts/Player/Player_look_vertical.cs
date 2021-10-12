using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_look_vertical : MonoBehaviour
{
    private float rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation=0;
    }

    // Update is called once per frame
    void Update()
    {
        rotation-=Input.GetAxis("Mouse Y")*Time.deltaTime*1000;
        rotation=Mathf.Clamp(rotation,-90f,90f);
        transform.localRotation=Quaternion.Euler(rotation,0,0);
    }
}
