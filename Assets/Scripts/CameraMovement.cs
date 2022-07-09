using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject hole;
    [SerializeField] Vector3 distance;
    void Update()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        transform.position = hole.transform.position + distance;
    }
}
