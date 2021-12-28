using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveMinigame : MonoBehaviour
{
    public GameObject Painting;
    public GameObject[] StoveFires;
    public bool IsFinished;

    private bool IsCompleted()
    {
        return StoveFires[0].activeSelf &&
               StoveFires[1].activeSelf &&
               StoveFires[2].activeSelf &&
               !StoveFires[3].activeSelf;

    }

    public void Check()
    {
        if (IsCompleted())
        {
            Painting.SetActive(true);
            IsFinished = true;
            Debug.Log("stove minigame completed");
        }
    }
}
