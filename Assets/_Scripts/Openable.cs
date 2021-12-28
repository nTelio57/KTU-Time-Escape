using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Openable : MonoBehaviour
{
    [SerializeField]
    protected Animator Animator;

    [SerializeField]
    public AudioSource DoorOpenSound;
    [SerializeField]
    public AudioSource DoorCloseSound;
    [SerializeField]
    public AudioSource DoorLockSound;

    [SerializeField]
    private BedroomMinigame BedroomMinigame;

    public bool IsOpen;
    public bool IsLocked;
    public InteractableItem Key;

    public virtual void Trigger()
    {
        if (IsLocked)
            return;

        if (IsOpen)
        {
            if (DoorOpenSound != null)
                DoorOpenSound.Play();

            Animator.SetBool("isOpen", false);
            IsOpen = false;
        }
        else
        {
            if (DoorCloseSound != null)
                DoorCloseSound.Play();

            Animator.SetBool("isOpen", true);
            IsOpen = true;
        }
    }

    private void Unlock()
    {
        if(DoorLockSound != null)
            DoorLockSound.Play();

        IsLocked = false;

        if (BedroomMinigame != false)
            BedroomMinigame.Trigger();
    }

    public bool CheckKey(InteractableItem key)
    {
        if (Key.Equals(key))
        {
            Unlock();
            return true;
        }

        return false;
    }
}

