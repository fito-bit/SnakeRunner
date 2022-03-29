using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private  float rotSpeed;
    private Manager gameManager;
    
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    private void Update()
    {
        transform.Rotate(0,rotSpeed*Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.UpdateCrystals();
            this.gameObject.SetActive(false);
        }
    }

    
}
