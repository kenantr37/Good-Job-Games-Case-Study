using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool _isPlayerOnFirstPart;
    [SerializeField] bool _followWayToSecondPart;
    [SerializeField] bool _isPlayerOnSecondPart;
    [SerializeField] bool _isGameOver;
    public bool IsPlayerOnFirstPart { get { return _isPlayerOnFirstPart; } set { _isPlayerOnFirstPart = value; } }
    public bool FollowWayToSecondPart { get { return _followWayToSecondPart; } set { _followWayToSecondPart = value; } }
    public bool IsPlayerOnSecondPart { get { return _isPlayerOnSecondPart; } set { _isPlayerOnSecondPart = value; } }
    public bool IsGameOver { get { return _isGameOver; } set { _isGameOver = value; } }
    void Start()
    {
        _isPlayerOnFirstPart = true;
        IsGameOver = false;
    }
    void Update()
    {
        GameOverManager();
    }
    void GameOverManager()
    {
        if (_isGameOver)
        {
            SceneManager.LoadScene(0);
        }
    }
}
