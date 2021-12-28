using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text TimerText;

    [SerializeField]
    private TMP_Text PointsText;

    [SerializeField]
    private TMP_Text PickupsText;

    [SerializeField]
    private RectTransform GameOverPanel;

    [SerializeField]
    private GameObject PauseMenuPanel;

    [SerializeField]
    private Text HighScoreText;

    [SerializeField]
    private Text HighScoreList;

    private void Awake()
    {
        UpdatePoints(0);
        UpdatePickupsAmounts(0);
        UpdateTime(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePauseMenu();
    }

    public void UpdateTime(int timeSeconds)
    {
        int minutes = timeSeconds / 60;
        int seconds = timeSeconds % 60;

        TimerText.text = ($"{minutes:00}:{seconds:00}");
    }

    public void UpdatePoints(int points)
    {
        PointsText.text = $"Points: {points}";
    }

    public void UpdatePickupsAmounts(int amount)
    {
        //PickupsText.text = $"Pickups: {amount}";
    }

    public void DisplayGameOverPanel(int amount)
    {
        HighScoreText.text = $"Your Score: {amount}";
        GameOverPanel.gameObject.SetActive(true);
    }

    public void DisplayHighscores(Dictionary<string, int> highscores)
    {
        var scores = highscores.OrderByDescending(s => s.Value);

        HighScoreList.text = "";
        foreach (var hs in scores)
        {
            HighScoreList.text += $"{hs.Key}\t\t{hs.Value}\n";
        }
    }

    private void TogglePauseMenu()
    {
        if (PauseMenuPanel.activeSelf)//deactivate
        {
            Time.timeScale = 1f;
            PauseMenuPanel.SetActive(false);
            StateManager.IsLocked = false;
            Cursor.visible = false;
        }
        else//activate
        {
            Time.timeScale = 0f;
            PauseMenuPanel.SetActive(true);
            StateManager.IsLocked = true;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        TogglePauseMenu();
    }
}
