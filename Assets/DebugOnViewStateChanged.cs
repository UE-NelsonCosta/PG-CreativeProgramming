using UnityEngine;

public class DebugOnViewStateChanged : MonoBehaviour
{
    public void OnViewStateChanged(GameObject ViewTarget)
    {
        const string NullString = "null";
        Debug.Log($"View Target Changed To { (ViewTarget != null ? ViewTarget.name : NullString )}" );
    }

    public void SwitchComponentStatesWhenViewChanges(GameObject ViewTarget)
    {
        if (ViewTarget != null)
        {
            GetComponent<MoveThroughPatrolRoute>().enabled = false;
            GetComponent<ChaseToLastKnownPoint>().enabled = true;
            return;
        }

        if (ViewTarget == null)
        {
            GetComponent<MoveThroughPatrolRoute>().enabled = true;
            GetComponent<ChaseToLastKnownPoint>().enabled = false;
        }

        //GetComponent<MoveThroughPatrolRoute>().enabled = ViewTarget == null;
        //GetComponent<ChaseToLastKnownPoint>().enabled = ViewTarget != null;
    }
}
