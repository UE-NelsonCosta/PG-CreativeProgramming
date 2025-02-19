using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveThroughPatrolRoute : MonoBehaviour
{
    [SerializeField] private PatrolRoute PatrolRouteToFollow = null;
    
    private NavMeshAgent Agent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!Agent.hasPath)
        {
            Agent.SetDestination( PatrolRouteToFollow.RequestNextPoint() );
        }

    }
}
