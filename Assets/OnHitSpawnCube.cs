using System.Collections;
using UnityEngine;

public class OnHitSpawnCube : MonoBehaviour
{
    [SerializeField] private GameObject TemplateToInstantiate = null;

    [SerializeField] private float GracePeriodBeforeInstantiationIsAvailable = 1.0f;
    
    private bool CanInstantiate = false;
    
    private void Start()
    {
        StartCoroutine(GracePeriodBeforeInstantiation());
        
        Destroy(this.gameObject, 10.0f);
    }

    private IEnumerator GracePeriodBeforeInstantiation()
    {
        yield return new WaitForSeconds(GracePeriodBeforeInstantiationIsAvailable);

        CanInstantiate = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        // Guard Clause Example
        if ( !CanInstantiate || !other.gameObject.CompareTag("Borders") )
            return;
            
        Instantiate
        (
            TemplateToInstantiate,
            transform.position + new Vector3(UnityEngine.Random.Range(-2, 2), 2, UnityEngine.Random.Range(-2, 2)),
            transform.rotation
        );
    }
}
