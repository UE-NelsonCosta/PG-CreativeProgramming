using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class RotateTowardsForwardMovementVector : MonoBehaviour
{
    private PhysicsBasedCharacterMovement CharacterMover = null;

    private void Start()
    {
        CharacterMover = GetComponent<PhysicsBasedCharacterMovement>();
    }

    private void Update()
    {
        if (!CharacterMover.HasMovedThisFrame())
            return;
        
        Vector3 InitialRotation = transform.rotation.eulerAngles;
        Vector3 TargetRotation = Camera.main.transform.rotation.eulerAngles;

        TargetRotation.x = 0.0f;
        TargetRotation.z = 0.0f;
        
        Vector3 LerpedRotation = Vector3.Lerp(InitialRotation, TargetRotation, 0.2f);

        transform.rotation = Quaternion.Euler(LerpedRotation);
    }
}
