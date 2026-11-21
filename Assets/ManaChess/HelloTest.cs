using System;
using ManaChess.Core;
using UnityEngine;

public class HelloTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var greeter = new Position();
        Debug.Log(greeter);
    }

    // Update is called once per frame
}
