using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalSphere : MonoBehaviour
{
    [SerializeField] GameObject centerOfHole, hole;
    Rigidbody sphere;
    void Awake()
    {
        sphere = GetComponent<Rigidbody>();
    }
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
        if (Vector3.Distance(transform.position, hole.transform.position) <= 1.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, centerOfHole.transform.position, Time.deltaTime * .8f);
            sphere.WakeUp();
        }
    }
}
