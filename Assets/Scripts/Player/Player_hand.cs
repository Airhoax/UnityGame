using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_hand : MonoBehaviour
{

    private bool  placeMode;
    private bool canPlace;
    private int handFilled;
    private GameObject handFull;
    private Transform item;
    private Transform copy;
    public Transform items;
    private Transform right;
    private Transform left;

    // Start is called before the first frame update
    void Start()
    {
        placeMode=false;
        handFilled=0;
        right=transform.GetChild(0);
        left=transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        //place mode 
        if(Input.GetButtonDown("Place Mode")){placeMode=!placeMode;}
        if(handFilled==0 || handFilled==3){placeMode=false;}

        //pick hand and count items
        if(!placeMode )
        {
            if(transform.childCount>2)
            {
                if(handFilled==1)
                {
                    transform.GetChild(2).SetParent(left);
                    handFull = new GameObject("handFull");
                    handFull.transform.SetParent(transform);
                    handFilled=2;
                }
                else if(handFilled==0)
                {
                    transform.GetChild(2).SetParent(right);
                    handFilled=1;
                }
                if(handFilled==1 || handFilled==3){Destroy(handFull);}
            }

            //switch hand
            if(handFilled>0 && Input.GetButtonDown("Switch"))
            {
                switch (handFilled)
                {
                    case 1:
                    handFilled=3;
                    right.GetChild(0).SetParent(left);
                    break;
                    case 3:
                    handFilled=1;
                    left.GetChild(0).SetParent(right);
                    break;
                    case 2:
                    right.GetChild(0).SetParent(left);
                    left.GetChild(0).SetParent(right);
                    break;
                    default:
                    break;
                }
            }
        

            //end place mode
            if(right.childCount==2)
            {
                item.position=copy.position;
                item.rotation=copy.rotation;
                Destroy(copy.gameObject);
            }
        }

        //place mode on
        if(placeMode)
        {
            //position item
            item = right.GetChild(0); 
            item.rotation=new Quaternion(-transform.rotation.x,0f,-transform.rotation.z,0f);
            item.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeAll;
            item.GetComponent<Collider>().isTrigger=true;
            item.position=transform.position;
            if(right.childCount==1)
            {
                copy=Instantiate(item,right.position,right.rotation);
                copy.SetParent(right);
            }
            //drop
            if(Input.GetButtonDown("Pick Up Drop"))
            {
                placeMode=false;
                item.SetParent(items);
                item.GetComponent<Collider>().isTrigger=false;
                item.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezeRotation;
                Destroy(copy.gameObject);
                if(left.childCount==1){handFilled=3;}
                else{handFilled=0;}
            }
        }
    }
}
