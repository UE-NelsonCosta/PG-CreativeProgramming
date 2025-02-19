using System;
using UnityEngine;
using UnityEngine.AI;

public class AISoldier_PatrolState : AStateBehaviour
{
    [SerializeField] private PatrolRoute AgentPatrolRoute;
    private NavMeshAgent Agent;
    private AISense AISenseComponent;

    private Vector3 PatrolPoint = Vector3.zero;
    
    public override bool InitializeState()
    {
        Agent = GetComponent<NavMeshAgent>();
        AISenseComponent = GetComponent<AISense>();
        
        if (Agent == null || AgentPatrolRoute == null || AISenseComponent == null)
        {
            return false;
        }

        return true;
    }

    public override void OnStateStart()
    {
        if (PatrolPoint == Vector3.zero)
        {
            PatrolPoint = AgentPatrolRoute.RequestNextPoint();
        }

        Agent.SetDestination(PatrolPoint);
    }

    public override void OnStateUpdate()
    { }

    public override void OnStateEnd()
    { }

    public override Type StateTransitionCondition()
    {
        if (!Agent.hasPath)
        {
            PatrolPoint = Vector3.zero;

            return typeof(AISoldier_IdleState);
        }

        if (AISenseComponent.HasSeenPlayerThisFrame())
        {
            return typeof(AISoldier_ChaseState);
        }

        return null;
    }
}
