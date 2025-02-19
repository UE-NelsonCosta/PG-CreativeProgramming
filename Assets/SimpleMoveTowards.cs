using Unity.VisualScripting;
using UnityEngine;

public class SimpleMoveTowards : MonoBehaviour
{
    [SerializeField] private Transform ObjectToFollow;

    [SerializeField] private float MovementSpeed = 3.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Direction = (ObjectToFollow.position - transform.position).normalized;

        transform.position += Direction * Time.deltaTime * MovementSpeed;
    }
}
