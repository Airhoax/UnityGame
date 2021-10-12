using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_hand : MonoBehaviour
{
    public Transform item;
    private Transform inHoldingItem;
    public Transform holding;
    private Rigidbody itemRigitbody;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //item drop
        if(Input.GetButtonDown("Pick Up Drop") && transform.childCount>0 && holding.childCount>0)
        {
            //enable cpllider
            item.GetComponent<Collider>().enabled=true;
            //unfreez item rigitbody
            itemRigitbody.constraints = RigidbodyConstraints.FreezeRotation;
            //removes item from hand
            item.parent=null;
            //destroy in hand item
            Destroy(inHoldingItem.gameObject);
        }

        //no item in hand
        if(transform.childCount==0){item=null;}
        
        //item in hand
        else if(holding.childCount>0)
        {
            //controls rotation off item in hand and item
            item.rotation=new Quaternion(-transform.rotation.x,0f,-transform.rotation.z,0f);
            inHoldingItem.rotation=holding.rotation;
        }

        //on item picked up
        else if(holding.childCount==0)
        {
            //get item
            item=transform.GetChild(0);
            itemRigitbody=item.GetComponent<Rigidbody>();
            //freez item rigitbody
            itemRigitbody.constraints=RigidbodyConstraints.FreezeAll;
            //disable item colider
            item.GetComponent<Collider>().enabled=false;
            //position item
            item.position=transform.position;
            //create in hand item
            inHoldingItem = Instantiate(item,holding.position,holding.rotation);
            inHoldingItem.SetParent(holding);
            //change original item material !!!this will change soon!!!
            item.GetComponent<Renderer>().material.color=Color.blue;
        }
    }
}
