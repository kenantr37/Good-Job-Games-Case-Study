using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    [SerializeField] GameObject cubeDestination, hole;
    float speed = 4f;

    // PROGRESS BAR
    ProgressBar progressBar;
    SecondProgressBar secondProgressBar;
    int firstPartObstacles_amount;
    int secondPartObstacles_amount;


    void Awake()
    {
        progressBar = FindObjectOfType<ProgressBar>();
        secondProgressBar = FindObjectOfType<SecondProgressBar>();

    }
    void Start()
    {
        Physics.gravity *= 1f;

        GameObject[] firstPartObstacles = GameObject.FindGameObjectsWithTag("FirstPartObstacle");
        firstPartObstacles_amount = firstPartObstacles.Length;

        GameObject[] secondPartObstacles = GameObject.FindGameObjectsWithTag("SecondPartObstacle");
        secondPartObstacles_amount = secondPartObstacles.Length;

        progressBar.progressSlider.maxValue = firstPartObstacles_amount;
        secondProgressBar.secondProgressSlider.maxValue = secondPartObstacles_amount;

    }
    void Update()
    {
        DestroyCubes();
        MoveToCenter();
    }
    void DestroyCubes()
    {
        if (transform.position.y <= -.5f)
        {
            Destroy(gameObject);
        }
    }
    void MoveToCenter()
    {
        if (Vector3.Distance(transform.position, hole.transform.position) <= 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, cubeDestination.transform.position, Time.deltaTime * speed);
            Vector3 rotationDirection = transform.position - hole.transform.position;
            Quaternion rotation = Quaternion.LookRotation(rotationDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HoleCenter") && gameObject.CompareTag("FirstPartObstacle"))
        {
            progressBar.progressSlider.value += 1;
            Handheld.Vibrate();
        }
        if (collision.gameObject.CompareTag("HoleCenter") && gameObject.CompareTag("SecondPartObstacle"))
        {
            secondProgressBar.secondProgressSlider.value += 1;
            Handheld.Vibrate();
        }
    }
}