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

    void Move(int direction)
    {
        transform.Translate(2*direction * speed * Time.deltaTime, 0, speed * Time.deltaTime);
    }

    void Update()
    {
        if (StaticValues.gameState == GameState.Playing && isHead)
        {
            if (!snakeScript.isFever)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        targetPosition = hit.point;
                    }
                }
                
                if (Math.Abs(transform.position.x-targetPosition.x)<=0.01f)
                {
                    transform.Translate(0, 0, speed * Time.deltaTime);
                }
                else
                {
                    if (targetPosition.x < transform.position.x)
                    {
                        Move(-1);
                    }
                    else if (targetPosition.x > transform.position.x)
                    {
                        Move(1);
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
