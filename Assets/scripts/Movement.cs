using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 0.01f;
    [SerializeField] private KeyCode MovUp = KeyCode.W;
    [SerializeField] private KeyCode MovDown = KeyCode.S;
    [SerializeField] private KeyCode MovRight = KeyCode.D;
    [SerializeField] private KeyCode MovLeft = KeyCode.A;


    public float rotationSpeed = 10.0f;
    public KeyCode rotateToRight = KeyCode.Q;
    public KeyCode rotateToLeft = KeyCode.E;

    public KeyCode changeColor = KeyCode.R;

    private SpriteRenderer spriteRenderer;




    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    

    void Update()
    {
        Rotate();
        ChangeColor();

        Vector3 pos = transform.position;
        

        if (Input.GetKey(MovUp))
        {
            pos.y += movementSpeed;
        }

        if (Input.GetKey(MovLeft))
        {
            pos.x -= movementSpeed;
        }

        if (Input.GetKey(MovDown))
        {
            pos.y -= movementSpeed;
        }

        if (Input.GetKey(MovRight))
        {
            pos.x += movementSpeed;


        }

        transform.position = pos;
        
    }
    

    private void ChangeColor()
    {
        if (Input.GetKeyUp(changeColor))
        {
            float red = Random.Range(0f, 1.0f);
            float green = Random.Range(0f, 1.0f);
            float blue = Random.Range(0f, 1.0f);
            float alpha = Random.Range(0.2f, 0.8f);

            spriteRenderer.color = new Color(red, green, blue, alpha);
        }
    }

    private void Rotate()
    {
        if (Input.GetKeyDown(rotateToRight))
        {
            transform.Rotate(0, 0, rotationSpeed);
        }

        if (Input.GetKeyDown(rotateToLeft))
        {
            transform.Rotate(0, 0, -rotationSpeed);
        }
    }

    public void SetMovementSpeed(float newSpeed)
    {
        if (newSpeed < 1.5f)
        movementSpeed = newSpeed;
    }
    public float GetMovementSpeed()
{
    return movementSpeed;
}

    
}
