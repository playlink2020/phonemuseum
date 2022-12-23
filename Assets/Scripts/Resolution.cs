using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    void Awake()
    {
        Screen.SetResolution(720, 1280, false);
    }
}
