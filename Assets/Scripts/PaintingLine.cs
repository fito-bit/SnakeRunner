using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingLine : MonoBehaviour
{
    public MeshRenderer renderer;
    private Manager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        renderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"||other.gameObject.tag == "Part")
        {
            manager.currentColor = this.renderer.material.color;
            other.gameObject.GetComponent<Movement>().meshRenderer.material = this.renderer.material;
        }
    }
}
