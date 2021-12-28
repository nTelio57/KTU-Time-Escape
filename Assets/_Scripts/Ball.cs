using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioSource BounceSound;
    public string IgnoreTag;

    private void OnCollisionEnter(Collision other)
    {
        if(String.CompareOrdinal(other.gameObject.tag, IgnoreTag) != 0)
            BounceSound.Play();
    }
}
