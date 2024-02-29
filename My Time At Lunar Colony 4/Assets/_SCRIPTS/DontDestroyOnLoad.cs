using System;
using System.Collections;
using UnityEngine;


public class DontDestroyOnLoad : MonoBehaviour
{

  private void Awake()
  {
    DontDestroyOnLoad(gameObject);
  }

}