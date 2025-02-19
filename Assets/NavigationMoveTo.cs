using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavigationMoveTo : MonoBehaviour
{
    [SerializeField] private Transform PointToFollow;
    
    private NavMeshAgent Agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Agent)
        {
            Debug.LogError("Missing Agent Component");
            return;
        }

        if (Agent.SetDestination(PointToFollow.position))
        {
            Debug.LogWarning("Failed To Move To Point");
        }
    }
}
