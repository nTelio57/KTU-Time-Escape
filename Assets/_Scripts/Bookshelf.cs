using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : Openable
{
    [Header("Bookshelf")]
    public GameObject ParticleSystems;
    public GameObject MissingBookObject;
    [SerializeField]
    private float _particleDuration;
    public GameObject Wall;
    public override void Trigger()
    {
        if (IsLocked)
            return;

        if (!IsOpen)
        {
            Animator.SetBool("isOpen", true);
            IsOpen = true;
            Wall.SetActive(false);
            MissingBookObject.SetActive(true);
            StartCoroutine(DustParticleSystems());
        }
        /*else
        {
            Animator.SetBool("isOpen", false);
            IsOpen = false;
            StartCoroutine(DustParticleSystems());
        }*/
    }

    IEnumerator DustParticleSystems()
    {
        ParticleSystems.SetActive(true);
        yield return new WaitForSeconds(_particleDuration);
        ParticleSystems.SetActive(false);
    }
}
