using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] GameObject cubeDestionation, hole;
    [SerializeField] float speed;

    void Start()
    {
        Physics.gravity *= 1f;
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
        if (Vector3.Distance(transform.position, hole.transform.position) <= .9f)
        {
            transform.position = Vector3.MoveTowards(transform.position, cubeDestionation.transform.position, Time.deltaTime * speed);
        }
    }
}
