using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] GameObject cubeDestionation, hole;
    float speed = 4f;

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
        if (Vector3.Distance(transform.position, hole.transform.position) <= 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, cubeDestionation.transform.position, Time.deltaTime * speed);
            Vector3 rotationDirection = transform.position - cubeDestionation.transform.position;
            Quaternion rotation = Quaternion.LookRotation(rotationDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        }
    }
}
