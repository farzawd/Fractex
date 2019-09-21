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
