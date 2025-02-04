using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    private bool IsAnimating = false;
    [SerializeField] private float AnimationTime = 1.0f;
    [SerializeField] private float MaxAngle = 1.0f;
    [SerializeField] private AnimationCurve animationCurve;

    private float AnimationTimeTracker = 0.0f;
    
    public void PlayAnimation()
    {
        //IsAnimating = true;

        //AnimationTimeTracker = 0.0f;
        
        GetComponent<Animator>().SetTrigger("OpenDoor");
    }

    private void Update()
    {
        if (!IsAnimating)
            return;
        
        Debug.Log(AnimationTimeTracker);
        
        AnimationTimeTracker += Time.deltaTime / AnimationTime;
        if (AnimationTimeTracker >= 1)
        {
            IsAnimating = false;
        }

        transform.rotation = Quaternion.Euler(new Vector3( 0, animationCurve.Evaluate(AnimationTimeTracker) * MaxAngle, 0 ));
    }
}
