using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] public float MaxVelocity = 10.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Input = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0, UnityEngine.Input.GetAxis("Vertical"));

        Vector3 WorldDirection = (Input.z * Camera.main.transform.forward + Input.x * Camera.main.transform.right)
            .normalized;
        
        GetComponent<Rigidbody>().linearVelocity = new Vector3
            (
                WorldDirection.x * MaxVelocity,
                GetComponent<Rigidbody>().linearVelocity.y,
                WorldDirection.y * MaxVelocity
            );
    }
}
