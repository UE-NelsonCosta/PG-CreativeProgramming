using System;
using UnityEngine;

public class AISoldier_IdleState : AStateBehaviour
{
    [SerializeField] private float BaseTimeToWait = 2.0f;
    [SerializeField] private float RandomHalfRange = 1.0f;

    private AISense AISenseComponent = null;
    
    private float Timer = 0.0f;
    
    public override bool InitializeState()
    {
        AISenseComponent = GetComponent<AISense>();

        return AISenseComponent != null;
    }

    public override void OnStateStart()
    {
        Timer = BaseTimeToWait + UnityEngine.Random.Range(-RandomHalfRange, RandomHalfRange);
    }

    public override void OnStateUpdate()
    {
        Timer -= Time.deltaTime;
    }

    public override void OnStateEnd()
    { }

    public override Type StateTransitionCondition()
    {
        if (Timer <= 0.0f)
        {
            return typeof(AISoldier_PatrolState);
        }

        if (AISenseComponent.HasSeenPlayerThisFrame())
        {
            return typeof(AISoldier_ChaseState);
        }

        return null;
    }
}
