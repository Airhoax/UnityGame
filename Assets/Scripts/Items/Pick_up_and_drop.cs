using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_up_and_drop : MonoBehaviour
{
    public Transform hand;
    private bool hover;
    
    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.Find("Player Hand").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pick Up Drop") && hover  && hand.childCount==0)
        {
            transform.SetParent(hand);
        }
    }

    void OnMouseEnter(){hover=true;}
    void OnMouseExit(){hover=false;}
}
