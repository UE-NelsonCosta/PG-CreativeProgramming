using UnityEngine;

public class FindTargetUsingRaycast : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        LayerMask layerMask = ~(1 << LayerMask.NameToLayer("Player"));
        RaycastHit HitInformation;
        if (Physics.Raycast(transform.position, transform.forward, out HitInformation, 10.0f, layerMask))
        {
            Debug.DrawLine(transform.position, HitInformation.point, Color.green);

            Debug.Log(HitInformation.transform.gameObject.name);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward * 10.0f, Color.red);
        }
    }
}
