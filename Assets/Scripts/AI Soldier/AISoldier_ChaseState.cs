using System;
using UnityEngine;
using UnityEngine.AI;

public class AISoldier_ChaseState : AStateBehaviour
{
    private NavMeshAgent Agent;
    private AISense AISenseComponent;

    private Vector3 LastPlayerKnownPosition;
    
    public override bool InitializeState()
    {
        Agent = GetComponent<NavMeshAgent>();
        AISenseComponent = GetComponent<AISense>();
        
        if (Agent == null || AISenseComponent == null)
        {
            return false;
        }

        return true;
    }

    public override void OnStateStart()
    {
        if (AISenseComponent.GetVisbilePlayerObject() == null)
        {
            // Soemthings gone terribly wrong
            AssociatedStateMachine.SetState(typeof(AISoldier_IdleState));
            return;
        }

        LastPlayerKnownPosition = AISenseComponent.GetVisbilePlayerObject().transform.position;
        
        Agent.SetDestination(LastPlayerKnownPosition);
    }

    public override void OnStateUpdate()
    {
        GameObject PlayerObject = AISenseComponent.GetVisbilePlayerObject();
        if (PlayerObject != null)
        {
            LastPlayerKnownPosition = PlayerObject.transform.position;
            Agent.SetDestination(LastPlayerKnownPosition);
        }
    }

    public override void OnStateEnd()
    {
    }

    public override Type StateTransitionCondition()
    {
        if (!Agent.hasPath)
        {
            return typeof(AISoldier_IdleState);
        }
        
        return null;
    }
}
