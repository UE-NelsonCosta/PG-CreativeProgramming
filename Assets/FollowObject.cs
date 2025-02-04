using Unity.VisualScripting;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private GameObject followTarget = null;

    private void Update()
    {
        transform.LookAt(followTarget.transform.position);
    }
}
