using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    MeshCollider meshCollider;
    GameManager gameManager;
    ProgressBar progressBar;

    int firstPartObstacles_amount;
    void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();
        gameManager = FindObjectOfType<GameManager>();
        progressBar = FindObjectOfType<ProgressBar>();
    }
    void Start()
    {
        GameObject[] firstPartObstacles = GameObject.FindGameObjectsWithTag("FirstPartObstacle");
        firstPartObstacles_amount = firstPartObstacles.Length;
        progressBar.progressSlider.maxValue = firstPartObstacles_amount;
    }
    void Update()
    {
        meshCollider.enabled = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FirstPartObstacle"))
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            meshCollider.enabled = false;
        }
        if (collision.gameObject.CompareTag("SecondPartObstacle"))
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            meshCollider.enabled = false;
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            meshCollider.enabled = false;
            StartCoroutine(GameOverTimer());
        }
        if (collision.gameObject.CompareTag("IntervalObstacles"))
        {
            collision.gameObject.GetComponent<SphereCollider>().enabled = false;
            meshCollider.enabled = false;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("FirstPartObstacle"))
        {
            progressBar.progressSlider.value += 1;
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            meshCollider.enabled = false;
        }
        if (collision.gameObject.CompareTag("SecondPartObstacle"))
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            meshCollider.enabled = false;
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            meshCollider.enabled = false;
            StartCoroutine(GameOverTimer());
        }
        if (collision.gameObject.CompareTag("IntervalObstacles"))
        {
            collision.gameObject.GetComponent<SphereCollider>().enabled = false;
            meshCollider.enabled = false;
        }
    }
    IEnumerator GameOverTimer()
    {
        yield return new WaitForSeconds(.5f);
        gameManager.IsGameOver = true;
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("FirstPartObstacle"))
        {
            progressBar.progressSlider.value += 1;
        }
    }
}