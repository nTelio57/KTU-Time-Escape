using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FootballMinigame : MonoBehaviour
{
    public GameObject[] Paintings;
    public GameObject BallObject;
    public InteractableItem FootballBall;
    public Transform SpawnPosition;
    public bool IsFinished;

    public void Goal()
    {
        if (!IsFinished)
        {
            foreach (var go in Paintings)
            {
                go.SetActive(true);
            }
            IsFinished = true;
        }
    }

    public bool Respawn(InteractableItem ball)
    {
        if (ball != null && ball.Equals(FootballBall))
        {
            Instantiate(BallObject, SpawnPosition.position, Quaternion.identity);
            return true;
        }
        return false;
    }
}
