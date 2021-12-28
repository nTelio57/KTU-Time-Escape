using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballGoal : MonoBehaviour
{
    [SerializeField] 
    private FootballMinigame FootballMinigame;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            FootballMinigame.Goal();
        }
    }
}
