using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AISense : MonoBehaviour
{
    [SerializeField] private string TagToSearchFor = "Player"; 
    [SerializeField] private float ViewHalfAngleEuler = 45.0f;
    [SerializeField] private float ViewDistance = 10.0f;

    private GameObject ObjectSeenThisFrame = null;
    private Transform ObjectToTrack = null;

    public UnityEvent<GameObject> OnTargetViewStateChanged;

    private void Start()
    {
        ObjectToTrack = GameObject.FindWithTag(TagToSearchFor).transform;
    }

    private void Update()
    {
        float RadiansVisionCone = ViewHalfAngleEuler * Mathf.Deg2Rad;

        Vector3 ForwardVector = transform.forward;
        Vector3 DirectionToObject = (ObjectToTrack.position - transform.position).normalized;

        float DotProductToPlayer = Vector3.Dot(ForwardVector, DirectionToObject);
        float DistanceToPlayer = Vector3.Distance(transform.position, ObjectToTrack.position);
        if (DotProductToPlayer > RadiansVisionCone && DistanceToPlayer < ViewDistance)
        {
            if (Physics.Raycast(transform.position, DirectionToObject, out RaycastHit HitObject, ViewDistance))
            {
                if (HitObject.transform.CompareTag(TagToSearchFor))
                {
                    if (ObjectSeenThisFrame == HitObject.transform.gameObject)
                        return;
                    
                    ObjectSeenThisFrame = HitObject.transform.gameObject;
                    
                    OnTargetViewStateChanged.Invoke(ObjectSeenThisFrame);
                    
                    return;
                }
            }
        }

        if (ObjectSeenThisFrame != null)
        {
            OnTargetViewStateChanged.Invoke(null);
        }
        ObjectSeenThisFrame = null;
    }

    public bool HasSeenPlayerThisFrame()
    {
        return ObjectSeenThisFrame != null;
    }

    public GameObject GetVisbilePlayerObject()
    {
        return ObjectSeenThisFrame;
    }
}
