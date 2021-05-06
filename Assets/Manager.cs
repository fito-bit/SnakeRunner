using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Manager:MonoBehaviour
{
    [SerializeField] Text crystals;
    [SerializeField] Text humans;

    int humanCount=0;
    int crystalsCount=0;

    public void UpdateHumans()
    {
        humanCount++;
        humans.text = " Humans: " + humanCount;
    }
    public void UpdateCrystals()
    {
        crystalsCount++;
        crystals.text = " Crystals: " + crystalsCount;
    }
}
