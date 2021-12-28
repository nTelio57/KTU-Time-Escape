using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomMinigame : MonoBehaviour
{
    public GameObject[] Paintings;
    public bool IsFinished;

    public void Trigger()
    {
        IsFinished = true;
        foreach (var go in Paintings)
        {
            go.SetActive(true);
        }
    }
}
