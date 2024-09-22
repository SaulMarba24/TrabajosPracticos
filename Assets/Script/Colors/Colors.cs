using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Colors : MonoBehaviour
{
    [Header("Colors")]
    public KeyCode changeColor = KeyCode.R;

    private SpriteRenderer spriteRenderer;

      
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
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
}
