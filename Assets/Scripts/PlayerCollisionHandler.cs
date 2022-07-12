using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    MeshCollider meshCollider;
    GameManager gameManager;

    void Awake()
    {
        meshCollider = GetComponent<MeshCollider>();
        gameManager = FindObjectOfType<GameManager>();
    }
    void Start()
    {
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
            Handheld.Vibrate();
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
}