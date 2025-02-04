using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnHitAddForce : MonoBehaviour
{
    [SerializeField] private float forceImpulse = 10.0f;
    
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * forceImpulse, ForceMode.Impulse);
    }
}
