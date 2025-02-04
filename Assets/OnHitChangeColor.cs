using System;
using UnityEngine;

public class OnHitChangeColor : MonoBehaviour
{
    private MeshRenderer meshRenderer = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Color RandomizedColor = new Color
            (
                UnityEngine.Random.Range(0.0f, 1.0f),
                UnityEngine.Random.Range(0.0f, 1.0f),
                UnityEngine.Random.Range(0.0f, 1.0f),
                UnityEngine.Random.Range(0.0f, 1.0f)
            );
        
        meshRenderer.material.SetColor("_BaseColor", RandomizedColor);
    }
}
