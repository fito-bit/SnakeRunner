using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Human : MonoBehaviour
{
    private Manager gameManager;
    public MeshRenderer meshRenderer;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.GetComponent<Movement>().meshRenderer.material.color == meshRenderer.material.color||other.gameObject.GetComponentInParent<Snake>().isFever)
            {
                gameManager.UpdateHumans();
                Destroy(this.gameObject);
            }
            else
            {
                gameManager.EndGame();
            }
        }
    }
}
