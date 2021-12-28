using UnityEngine;
using UnityEngine.Audio;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private AudioMixer MasterAudioMixer;

    [SerializeField]
    private Animator MenuAnimator;

    [SerializeField]
    private AudioSource ClickSound;

    private static readonly int IsOpen = Animator.StringToHash("isOptionsOpen");

    public void SetVolume(float volume)
    {
        MasterAudioMixer.SetFloat("Volume", volume);
    }

    public void SetEffectsVolume(float volume)
    {
        MasterAudioMixer.SetFloat("Effects", volume);
    }

    public void Close()
    {
        PlayClickSound();
        MenuAnimator.SetBool(IsOpen, false);
    }

    public void PlayClickSound()
    {
        ClickSound.Play();
    }
}
