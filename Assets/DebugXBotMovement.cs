using Unity.VisualScripting;
using UnityEngine;

public class DebugXBotMovement : MonoBehaviour
{
    private Animator animator = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float InputX = Input.GetAxisRaw("Horizontal");
        float InputY = Input.GetAxisRaw("Vertical");

        float CurrentAnimatorForwardMovement = animator.GetFloat("ForwardMovement");
        float CurrentAnimatorSidewaysMovement = animator.GetFloat("SideMovement");
            
        animator.SetFloat("ForwardMovement", Mathf.Lerp(CurrentAnimatorForwardMovement, InputY, 0.2f) );
        animator.SetFloat("SideMovement", Mathf.Lerp(CurrentAnimatorSidewaysMovement, InputX, 0.2f) );
    }
}
