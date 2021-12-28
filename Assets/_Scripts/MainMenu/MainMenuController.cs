using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text TitleLabel;

    [SerializeField]
    private Animator MenuAnimator;

    [SerializeField] 
    private AudioSource ClickSound;

    private static readonly int IsOptionsOpen = Animator.StringToHash("isOptionsOpen");
    private static readonly int IsAboutOpen = Animator.StringToHash("isAboutOpen");

    public void Load()
    {
        PlayClickSound();
        TitleLabel.text = "Loading...";
        SceneManager.LoadScene(1);
    }

    public void OpenOptions()
    {
        PlayClickSound();
        MenuAnimator.SetBool(IsOptionsOpen, true);
    }

    public void OpenAbout()
    {
        PlayClickSound();
        MenuAnimator.SetBool(IsAboutOpen, true);
    }

    public void CloseAbout()
    {
        PlayClickSound();
        MenuAnimator.SetBool(IsAboutOpen, false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void PlayClickSound()
    {
        ClickSound.Play();
    }
}
