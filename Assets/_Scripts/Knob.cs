using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knob : MonoBehaviour
{
    [SerializeField]
    private GameObject ParticleObject;

    [SerializeField]
    private AudioSource ClickSound;

    [SerializeField]
    private AudioSource WhileActiveSound;

    [SerializeField]
    public bool CanActivate;
    public void Trigger()
    {
        if (!CanActivate) return;

        if (ParticleObject.activeSelf == false)
        {
            ParticleObject.SetActive(true);
            PlaySound(ClickSound);
            PlaySound(WhileActiveSound);
        }
        else
        {
            ParticleObject.SetActive(false);
            StopSound(WhileActiveSound);
        }
    }

    private void PlaySound(AudioSource sound)
    {
        if(sound != null)
            sound.Play();
    }

    private void StopSound(AudioSource sound)
    {
        if (sound != null)
            sound.Stop();
    }

}
