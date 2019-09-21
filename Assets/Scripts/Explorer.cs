using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explorer : MonoBehaviour
{
    [SerializeField] private Material material;
    
    [SerializeField] private Vector2 position;
    [SerializeField] private float scale;

    void Update()
    {
        HandleInput();
        UpdateShader();
    }

    private void HandleInput()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            scale *= .99f;
        }
        else if (Input.GetKey(KeyCode.KeypadMinus))
        {
            scale *= 1.01f;
        }

        var moveSpeed = scale / 100;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += moveSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= moveSpeed;
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            position.y += moveSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            position.y -= moveSpeed;
        }
    }
    
    private void UpdateShader()
    {
        float ar = (float) Screen.width / Screen.height;

        float scaleX = scale;
        float scaleY = scale;

        if (ar > 1f)
        {
            scaleY /= ar;
        }
        else
        {
            scaleX *= ar;
        }
        
        material.SetVector("_Area", new Vector4(position.x, position.y, scaleX, scaleY));
    }
}
