using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Manager _manager;

    private void Start()
    {
        _manager=GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponentInParent<Snake>().isFever)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                _manager.EndGame();
            }
        }
    }
}
