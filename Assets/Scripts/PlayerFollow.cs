using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;

    void Update()
    {
        if(StaticValues.gameState==GameState.Playing)
            transform.position = new Vector3(0,transform.position.y,player.transform.position.z+offset.z); 
    }
}
