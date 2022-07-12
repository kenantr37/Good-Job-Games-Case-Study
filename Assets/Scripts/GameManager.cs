using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] bool _isPlayerOnFirstPart;
    [SerializeField] bool _followWayToSecondPart;
    [SerializeField] bool _isPlayerOnSecondPart;
    [SerializeField] bool _isGameOver;
    [SerializeField] bool _nextLevelStart;

    [SerializeField] bool increaseScore;

    public bool IsPlayerOnFirstPart { get { return _isPlayerOnFirstPart; } set { _isPlayerOnFirstPart = value; } }
    public bool FollowWayToSecondPart { get { return _followWayToSecondPart; } set { _followWayToSecondPart = value; } }
    public bool IsPlayerOnSecondPart { get { return _isPlayerOnSecondPart; } set { _isPlayerOnSecondPart = value; } }
    public bool IsGameOver { get { return _isGameOver; } set { _isGameOver = value; } }
    public bool NextLevelStart { get { return _nextLevelStart; } set { _nextLevelStart = value; } }

    void Start()
    {
        _isPlayerOnFirstPart = true;
        IsGameOver = false;
    }
    void Update()
    {
        GameOverManager();
        NextLevel();
    }
    void GameOverManager()
    {
        if (_isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void NextLevel()
    {
        if (_nextLevelStart)
        {
            if (SceneManager.GetActiveScene().buildIndex >= 2)
            {
                SceneManager.LoadScene(0);
                Score.increaseScore = 0;
            }
            else
            {
                Score.increaseScore += 100;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
