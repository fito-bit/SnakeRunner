using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Snake : MonoBehaviour
{
    public List<Transform> bodyParts = new List<Transform>();
    public float minDistance = 0.25f;
    public int beginSize;
    public float speed = 1;
    public float rotationSpeed = 50;
    public GameObject bodyPrefabs;
    private float dis;
    private Transform curBodyPart;
    private Transform PrevBodyPart;
    public Color color;
    private Manager manager;
    public bool isFever=false;
    public GameObject head;



    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        for (int i = 0; i < beginSize - 1; i++)
        {
            AddBodyPart();
        }
    }
    
    void Update()
    {
        Move();
        if (Input.GetKey(KeyCode.Q))
            AddBodyPart();
    }

    public void Move()
    {
        float curSpeed = speed;
        for (int i = 1; i < bodyParts.Count; i++)
        {
            curBodyPart = bodyParts[i];
            PrevBodyPart = bodyParts[i - 1];
            dis = Vector3.Distance(PrevBodyPart.position,curBodyPart.position);
            Vector3 newPos = PrevBodyPart.position;
            newPos.y = bodyParts[0].position.y;
            var T = Time.deltaTime * dis / minDistance * curSpeed;
            if (T > 0.5f)
                T = 0.5f;
            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newPos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, PrevBodyPart.rotation, T);
        }
    }

    public void AddBodyPart()
    {
        GameObject obj=Instantiate(bodyPrefabs, bodyParts[bodyParts.Count - 1].position,
            bodyParts[bodyParts.Count - 1].rotation) as GameObject;
        obj.GetComponent<Movement>().meshRenderer.material.color = manager.currentColor;
        Transform newPart = obj.transform;
        newPart.SetParent(transform);
        bodyParts.Add(newPart);
    }
}
