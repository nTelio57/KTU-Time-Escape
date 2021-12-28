using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeKey : MonoBehaviour
{
    public string Value;
    [SerializeField] 
    private Safe Safe;

    public void Trigger()
    {
        if(Value.Equals("-"))
            Safe.OnDeleteClick();
        else
            Safe.OnNumPadClick(Value);
    }
}
