using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbInput : MonoBehaviour
{
    public GameObject LightObject;
    public bool IsFixed = false;
    public InteractableItem BulbNeeded;

    public bool Trigger(InteractableItem bulbNeeded)
    {
        if (BulbNeeded.Equals(bulbNeeded) && !IsFixed)
        {
            LightObject.SetActive(true);
            IsFixed = true;
            return true;
        }

        return false;
    }
}
