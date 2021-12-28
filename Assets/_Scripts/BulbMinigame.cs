using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbMinigame : MonoBehaviour
{
    public GameObject[] Paintings;
    public int TotalCountOfBulbsNeeded;
    private int _currentCount = 0;

    public void AddBulb()
    {
        _currentCount++;

        if (_currentCount == TotalCountOfBulbsNeeded)
        {
            //MINIGAME COMPLETE
            Debug.Log("Bulb minigame complete");
            foreach (var go in Paintings)
            {
                go.SetActive(true);
            }
        }
    }
}
