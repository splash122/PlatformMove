using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    private Rigidbody coinBody;
    private void Awake()
    {
        coinBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        coinBody.transform.Rotate(0f, 0f, 1f, Space.Self);
    }
}
