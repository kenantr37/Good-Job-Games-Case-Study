using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoleMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = .1f;

    Vector3 firstTouchPosition, secondTouchPosition;
    Vector3 positionDifference;
    Vector3 startPosition;

    GameManager gameManager;

    float firstVerticalSideBorderZMin = -23.415f;
    float firstVerticalSideBorderZMax = -15.698f;

    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        if (gameManager.IsPlayerOnFirstPart)
        {
            MovePlayer();
            PlayerBorder(firstVerticalSideBorderZMin, firstVerticalSideBorderZMax);
        }
        if (gameManager.IsPlayerOnSecondPart)
        {
            MovePlayer();
            PlayerBorder(-3.76f, 3.821f);
        }
        if (gameManager.IsGameOver)
        {
            transform.position = startPosition;
        }
    }
    void MovePlayer()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstTouchPosition.x = touch.position.x;
                firstTouchPosition.y = touch.position.y;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                secondTouchPosition.x = touch.position.x;
                secondTouchPosition.y = touch.position.y;
                positionDifference.x = secondTouchPosition.x - firstTouchPosition.x;
                positionDifference.y = secondTouchPosition.y - firstTouchPosition.y;

                if (positionDifference.x != firstTouchPosition.x && positionDifference.y != firstTouchPosition.y)
                {
                    float horizontalMove = Time.deltaTime * moveSpeed * positionDifference.x;
                    float verticalMove = Time.deltaTime * -moveSpeed * positionDifference.y;
                    transform.Translate(horizontalMove, verticalMove, 0);
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                firstTouchPosition = Vector3.zero;
                secondTouchPosition = Vector3.zero;
            }
        }
    }
    void PlayerBorder(float verticalSideMin, float verticalSideMax)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.23f, 2.23f),
            .52f, Mathf.Clamp(transform.position.z, verticalSideMin, verticalSideMax));
    }
}
