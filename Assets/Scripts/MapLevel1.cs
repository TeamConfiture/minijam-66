﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel1 : MapLevel
{
  void Start()
  {
    //nbWaveEnemies = 3;
    //nbWave = 3;
    //maxrand = 3;
    currentWave= 0;
    LoadScene = "Level3";
    BeginStart();
    parameters = new float[,] {
      { 
        AllowedCo.x, AllowedCo.x + spawnWidth, -AllowedCo.y-spawnWidth, AllowedCo.y + spawnWidth
      }, 
      { 
        -AllowedCo.x-spawnWidth,AllowedCo.x + spawnWidth, AllowedCo.y, AllowedCo.y + spawnWidth
      } 
      };;
    EndStart();
  }
}
