using System.Collections.Generic;
using UnityEngine;

public enum EPatrolStyle
{
    SequencialWrapping,
    PingPong
}

public class PatrolRoute : MonoBehaviour
{
    [SerializeField] private List<Transform> PatrolPointsToFollow = new List<Transform>();

    [SerializeField] private EPatrolStyle PatrolStyle;

    private int IncrementDirection = 1;

    private int CurrentPointIndex = 0;

    public Vector3 RequestNextPoint()
    {
        Vector3 PointToReturn = PatrolPointsToFollow[CurrentPointIndex].position;

        CurrentPointIndex += IncrementDirection;
        if (!IsValidIndex(CurrentPointIndex))
        {
            if (PatrolStyle == EPatrolStyle.SequencialWrapping)
            {
                CurrentPointIndex = 0;
            }

            if (PatrolStyle == EPatrolStyle.PingPong)
            {
                IncrementDirection *= -1;

                CurrentPointIndex += IncrementDirection * 2;
            }
        }

        return PointToReturn;
    }

    private bool IsValidIndex(int IndexToCheck)
    {
        return IndexToCheck >= 0 && IndexToCheck < PatrolPointsToFollow.Count;
    }
}
