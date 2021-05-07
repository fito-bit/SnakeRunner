using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    public float speed;
    public Vector3 targetPosition;
    public MeshRenderer meshRenderer;
    private Snake snakeScript;
    [SerializeField] private bool isHead=false;
    void Start()
    {
        snakeScript = GetComponentInParent<Snake>();
        targetPosition = transform.position;
    }

    void Update()
    {
        if (StaticValues.gameState == GameState.Playing && isHead)
        {
            if (!snakeScript.isFever)
            {
                if (Math.Abs(transform.position.x-targetPosition.x)<=0.01f)
                {
                    transform.Translate(0, 0, speed * Time.deltaTime);
                }
                else
                {
                    if (targetPosition.x < transform.position.x)
                    {
                        transform.Translate(-2 * speed * Time.deltaTime, 0, speed * Time.deltaTime);
                    }
                    else if (targetPosition.x > transform.position.x)
                    {
                        transform.Translate(2 * speed * Time.deltaTime, 0, speed * Time.deltaTime);
                    }
                }
                
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        targetPosition = hit.point;
                    }
                }
                if (Input.GetMouseButtonDown(0))
                 {
                     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                     RaycastHit hit;
                     if (Physics.Raycast(ray, out hit))
                     {
                        targetPosition = hit.point;
                     }
                 }
            }
            else
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
        }
    }
}
