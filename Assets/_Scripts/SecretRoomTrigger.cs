using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoomTrigger : MonoBehaviour
{
    [SerializeField]
    private Animator Animator;
 
    private void OnTriggerEnter(Collider other)
    {
        Animator.SetTrigger("Open");
    }
}
