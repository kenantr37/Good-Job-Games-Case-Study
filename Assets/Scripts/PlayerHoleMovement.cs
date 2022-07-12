using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoleMovement : MonoBehaviour
{
    float moveSpeed = .03f;
    [SerializeField] GameObject wayPoint;
    [SerializeField] bool cancelBorder;
    [SerializeField] bool reachedToWayPoint;
    [SerializeField] GameObject door;
    [SerializeField] int nextLevelChecker;

    Vector3 firstTouchPosition, secondTouchPosition;
    Vector3 positionDifference;
    Vector3 startPosition;

    GameManager gameManager;
    GameObject[] traps;

    float firstVerticalSideBorderZMin = -23.415f;
    float firstVerticalSideBorderZMax = -15.698f;

    public int counter;

    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        traps = GameObject.FindGameObjectsWithTag("Trap");
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
            if (!cancelBorder)
            {
                PlayerBorder(firstVerticalSideBorderZMin, firstVerticalSideBorderZMax);
            }
            FinishFirstPartOfGame();
        }
        if (gameManager.IsPlayerOnSecondPart)
        {
            MovePlayer();
            PlayerBorder(-3.76f, 3.821f);
            NextLevelGo();
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
                    float horizontalMove = positionDifference.x * moveSpeed * Time.deltaTime;
                    float verticalMove = positionDifference.y * -moveSpeed * Time.deltaTime;
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
            0.875f, Mathf.Clamp(transform.position.z, verticalSideMin, verticalSideMax));
    }
    void FinishFirstPartOfGame()
    {
        GameObject[] firstPartObstacles = GameObject.FindGameObjectsWithTag("FirstPartObstacle");
        counter = firstPartObstacles.Length - 1;

        foreach (GameObject firstObstacle in firstPartObstacles)
        {
            if (!firstObstacle.activeInHierarchy)
            {
                counter--;
            }
        }
        if (counter <= 0)
        {
            foreach (GameObject trap in traps)
            {
                trap.GetComponent<Trap>().enabled = false;
                trap.GetComponent<BoxCollider>().enabled = false;
                trap.GetComponent<Trap>().GetComponent<Rigidbody>().isKinematic = true;

            }
            Vector3 centerOfTheGame = new Vector3(0.03f, transform.position.y, transform.position.z);

            door.transform.Translate(Vector3.down * Time.deltaTime * 1.2f);
            transform.position = Vector3.MoveTowards(transform.position, centerOfTheGame, Time.deltaTime * 1.2f);

            StartCoroutine(GoToSecondPart());
            cancelBorder = true;
        }
    }
    IEnumerator GoToSecondPart()
    {
        moveSpeed = 0;
        yield return new WaitForSeconds(2f);

        if (!reachedToWayPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoint.transform.position, Time.deltaTime * 5f);

            if (Vector3.Distance(transform.position, wayPoint.transform.position) <= .005f)
            {
                reachedToWayPoint = true;
                gameManager.IsPlayerOnFirstPart = false;
                gameManager.IsPlayerOnSecondPart = true;
                moveSpeed = .03f;

                foreach (GameObject trap in traps)
                {
                    trap.GetComponent<Trap>().enabled = true;
                    trap.GetComponent<BoxCollider>().enabled = true;
                    trap.GetComponent<Trap>().GetComponent<Rigidbody>().isKinematic = false;

                }
            }
        }
    }
    void NextLevelGo()
    {
        GameObject[] secondPartObstacles = GameObject.FindGameObjectsWithTag("SecondPartObstacle");
        counter = secondPartObstacles.Length;

        foreach (GameObject firstObstacle in secondPartObstacles)
        {
            if (!firstObstacle.activeInHierarchy)
            {
                counter--;
            }
        }
        if (counter <= 0)
        {
            gameManager.NextLevelStart = true;
        }
    }
}