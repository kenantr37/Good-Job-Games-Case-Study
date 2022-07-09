using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    void Start()
    {
        Physics.gravity *= 1.1f;
    }
    void Update()
    {
        DestroyCubes();
    }
    void DestroyCubes()
    {
        if (transform.position.y <= -.5f)
        {
            Destroy(gameObject);
        }
    }
}
