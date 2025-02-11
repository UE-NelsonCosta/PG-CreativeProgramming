using UnityEngine;

public class PhysicsBasedCharacterMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody = null;

    [SerializeField] private float maxVelocity = 4.0f;

    private Transform cameraTransform = null;

    private bool hasMovedThisFrame = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        float InputHorizontal = Input.GetAxisRaw("Horizontal"); 
        float InputVertical = Input.GetAxisRaw("Vertical");

        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        Vector3 WorldDirectionToMoveToward = (cameraForward * InputVertical + cameraRight * InputHorizontal).normalized;

        rigidbody.linearVelocity = WorldDirectionToMoveToward * maxVelocity;
        
        hasMovedThisFrame = InputHorizontal != 0 || InputVertical != 0 ? true : false;
    }

    public bool HasMovedThisFrame()
    {
        return hasMovedThisFrame;
    }

}
