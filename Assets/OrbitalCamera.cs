using System;
using Unity.VisualScripting;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    [SerializeField] private Transform TargetToFollow = null;
    
    [SerializeField] private float RotationSpeedX = 180.0f;
    [SerializeField] private float RotationSpeedY = 180.0f;

    private void Start()
    {
        if (TargetToFollow == null)
        {
            Debug.LogError("Target To Follow Not Set!");
            this.enabled = false;
        }
    }

    private void Update()
    {
        float InputX = Input.GetAxis("Mouse X");
        float InputY = -Input.GetAxis("Mouse Y");

        transform.rotation = Quaternion.Euler
            (
                new Vector3
                    (
                        transform.eulerAngles.x + (InputY * RotationSpeedY * Time.deltaTime),
                        transform.eulerAngles.y + (InputX * RotationSpeedX * Time.deltaTime),
                        0.0f
                    )
            );

        transform.position = TargetToFollow.position - (transform.forward * 10);
    }
}
