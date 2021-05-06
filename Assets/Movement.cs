using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector3 targetPosition;
    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (targetPosition.x==transform.position.x)
        {
            transform.Translate(0,0,speed*Time.deltaTime);
        }
        else
        {
            if (targetPosition.x < transform.position.x)
            {
                transform.Translate(-2*speed*Time.deltaTime,0,speed*Time.deltaTime);
            }
            else
            {
                transform.Translate(2*speed*Time.deltaTime,0,speed*Time.deltaTime);
            }
        }
        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
 
            if (Physics.Raycast(ray, out hit)){
                Debug.Log(hit.point);
                targetPosition = hit.point;
            }
        }
    }
    
    
}
