using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameAndDelete : MonoBehaviour
{
    void Start()
    {
        GameRoot.current.LockMouseCursor();
        Destroy(gameObject);
    }
}