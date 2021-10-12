using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_camera : MonoBehaviour
{

    public GameObject cam1;
    public GameObject cam2;
    private bool curentOne;

    void Start()
    {
        curentOne=true;
    }

    void Update()
    {
        cam1.SetActive(curentOne);
        cam2.SetActive(!curentOne);
        if(Input.GetButtonDown("Camera")){curentOne=!curentOne;}
    }
}
