using System;
using UnityEngine;

public class OnTriggerActivateDoor : MonoBehaviour
{
    [SerializeField] private DoorAnimator doorAnimator = null;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!doorAnimator)
            return;
        
        if(!other.gameObject.CompareTag(""))
        
        doorAnimator.PlayAnimation();
    }

    private void OnTriggerStay(Collider other) { }

    private void OnTriggerExit(Collider other) { }
}
