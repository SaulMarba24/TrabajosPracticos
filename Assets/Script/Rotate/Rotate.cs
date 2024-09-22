using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Rotate")]
    [SerializeField]
    public float rotationSpeed = 10.0f;
    public KeyCode rotateToRight = KeyCode.Q;
    public KeyCode rotateToLeft = KeyCode.E;

     
    private void Update()
    {
        if (Input.GetKeyDown(rotateToRight))
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * 1000);
        }

        if (Input.GetKeyDown(rotateToLeft))
        {
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime * 1000);
        }
    }
}
