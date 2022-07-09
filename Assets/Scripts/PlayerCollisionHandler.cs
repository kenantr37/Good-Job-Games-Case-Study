using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    PlayerHoleMovement playerHoleMovement;
    void Awake()
    {
        playerHoleMovement = GetComponent<PlayerHoleMovement>();
    }

}
