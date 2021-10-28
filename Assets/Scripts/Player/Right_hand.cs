using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_hand : MonoBehaviour
{

    private Transform item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount==1)
        {
            item=transform.GetChild(0);
            item.rotation=transform.rotation;
            item.position=transform.position;
        }
        if(transform.childCount==2){
            item=transform.GetChild(1);
            item.rotation=transform.rotation;
            item.position=transform.position;
        }
    }
}
