using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    float timeTillDestroy = 3f;
    void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }
}
