using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_up : MonoBehaviour
{
    public Transform hand;
    private bool hover;
    public bool trigger;
    
    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.Find("Player Hand").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(hover && Input.GetButtonDown("Pick Up Drop") && hand.childCount<3 && transform.parent.name=="Items"){transform.SetParent(hand);}
    }

    void OnMouseEnter()
    {
        if(transform.parent!=hand){hover=true;}
    }
    void OnMouseExit(){
        if(transform.parent!=hand){hover=false;}
    }
    void OnTriggerExit(Collider other){trigger=false;}
    void OnTriggerStay(Collider other){trigger=true;}
}
