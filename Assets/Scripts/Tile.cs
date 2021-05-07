using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
   public Color goodColor;
   public Color deathColor;
   [SerializeField] private PaintingLine paintingLine;
   [SerializeField] private Human[] goodHumans;
   [SerializeField] private Human[] deathHumans;

   private void Start()
   {
      paintingLine.renderer.material.color = goodColor;
      foreach (var human in deathHumans)
      {
         human.meshRenderer.material.color = deathColor;
      }
      foreach (var human in goodHumans)
      {
         human.meshRenderer.material.color = goodColor;
      }
   }
}
