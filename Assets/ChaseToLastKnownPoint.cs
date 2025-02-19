using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Object = System.Object;

public class ChaseToLastKnownPoint : MonoBehaviour
{
    public UnityEvent<GameObject> LostSightOfTarget;

    private NavMeshAgent Agent = null;
    private AISense AiSenseComponent = null;
    private GameObject ObjectToTrack = null;
    
    private void Awake()
    {
        AiSenseComponent = GetComponent<AISense>();
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ObjectToTrack = AiSenseComponent.GetVisbilePlayerObject();
        if (ObjectToTrack == null)
        {
            LostSightOfTarget.Invoke(null);
            return;
        }

        Agent.SetDestination(ObjectToTrack.transform.position);
    }
}
