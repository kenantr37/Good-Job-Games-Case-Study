using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoleMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = .1f;

    Vector3 firstPosition, secondPosition;
    Vector3 positionDifference;

    GameManager gameManager;

    float firstVerticalSideBorderZMin = -23.415f;
    float firstVerticalSideBorderZMax = -15.698f;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }

    void Update()
    {
        if (!gameManager.IsFirstPartDone)
        {
            MovePlayerHole();
            PlayerBorder(firstVerticalSideBorderZMin, firstVerticalSideBorderZMax);
        }
    }
    void MovePlayerHole()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstPosition.x = touch.position.x;
                firstPosition.y = touch.position.y;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                secondPosition.x = touch.position.x;
                secondPosition.y = touch.position.y;
                positionDifference.x = secondPosition.x - firstPosition.x;
                positionDifference.y = secondPosition.y - firstPosition.y;

                if (positionDifference.x != firstPosition.x && positionDifference.y != firstPosition.y)
                {
                    float horizontalMove = Time.deltaTime * moveSpeed * positionDifference.x;
                    float verticalMove = Time.deltaTime * -moveSpeed * positionDifference.y;
                    transform.Translate(horizontalMove, verticalMove, 0);
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                firstPosition = Vector3.zero;
                secondPosition = Vector3.zero;
            }
        }
    }
    void PlayerBorder(float verticalSideMin, float verticalSideMax)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.23f, 2.23f),
            .52f, Mathf.Clamp(transform.position.z, verticalSideMin, verticalSideMax));
    }
}
