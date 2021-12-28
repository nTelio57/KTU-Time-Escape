using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIManager UIManager;


    [SerializeField]
    private int GameDuration = 15 * 60;

    [SerializeField]
    private RenderTexture PortalTexture;

    private int _score = 0;

    private const string HighScoreKey = "HighScores";

    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            UIManager.UpdatePoints(value);
        }
    }

    private int _pickupCount = 0;

    public int PickupCount
    {
        get => _pickupCount;
        set
        {
            _pickupCount = value;
            UIManager.UpdatePickupsAmounts(value);
        }
    }

    private Dictionary<string, int> _playerScores;

    private void Awake()
    {
        _playerScores = LoadPlayerHighScore();

        StateManager.IsLocked = false;
        StartCoroutine(Countdown());
    }

    private void Start()
    {
        SetupPortalTexture();
    }

    public void GameOver()
    {
        StopAllCoroutines();
        StateManager.IsLocked = true;
        EndGame();
    }

    private IEnumerator Countdown()
    {
        while (GameDuration > 0)
        {
            UIManager.UpdateTime(GameDuration);
            GameDuration--;
            yield return new WaitForSeconds(1);
        }

        EndGame();
    }

    private void EndGame()
    {
        int score = PickupCount + GameDuration;

        _playerScores.Add(DateTime.Now.ToString("s"), score);

        SavePlayerHighScore();

        StateManager.IsLocked = true;
        UIManager.UpdateTime(0);
        UIManager.DisplayGameOverPanel(score);
        UIManager.DisplayHighscores(_playerScores);
    }

    private void SetupPortalTexture()
    {
        PortalTexture.width = Screen.width;
        PortalTexture.height = Screen.height;
    }

    private void SavePlayerHighScore()
    {
        string data = _playerScores
            .Aggregate("", (current, playerScore) => current + $"{playerScore.Key}|{playerScore.Value};");

        PlayerPrefs.SetString(HighScoreKey, data);
        PlayerPrefs.Save();
    }

    private static Dictionary<string, int> LoadPlayerHighScore()
    {
        string data = PlayerPrefs.GetString(HighScoreKey);

        return string.IsNullOrEmpty(data)
            ? new Dictionary<string, int>()
            : CreateScoreDictionary(data);
    }

    private static Dictionary<string, int> CreateScoreDictionary(string data)
    {
        string[] lines = data.Split(';');
        lines = lines.Take(lines.Length - 1).ToArray();

        return lines
            .Select(line => line.Split('|'))
            .ToDictionary(pair => pair[0], pair => int.Parse(pair[1]));
    }

    private int GetNewestHighScore()
    {
        return _playerScores.OrderByDescending(s => s.Key).First().Value;
    }
}
