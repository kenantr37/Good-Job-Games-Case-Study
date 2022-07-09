using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool _isFirstPartDone;
    public bool IsFirstPartDone { get { return _isFirstPartDone; } set { _isFirstPartDone = value; } }
}
