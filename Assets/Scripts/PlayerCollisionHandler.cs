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
    void Update()
    {
        meshCollider.enabled = true;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Trap"))
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            meshCollider.enabled = false;
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            StartCoroutine(GameOverTimer());
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Trap"))
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            meshCollider.enabled = false;
        }
    }
    IEnumerator GameOverTimer()
    {
        yield return new WaitForSeconds(.5f);
        gameManager.IsGameOver = true;
    }
}
