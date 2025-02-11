using UnityEngine;

public class XBotAnimationEvents : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer RendererWithMaterial = null;

    private Color InitialColor;
    
    private void Start()
    {
        InitialColor = RendererWithMaterial.material.GetColor("_BaseColor");
    }

    public void ChangeColorRandomly()
    {
        RendererWithMaterial.material.SetColor
            (
                "_BaseColor",
                new Color
                    (
                        UnityEngine.Random.Range(0.0f, 1.0f),
                        UnityEngine.Random.Range(0.0f, 1.0f),
                        UnityEngine.Random.Range(0.0f, 1.0f),
                        1.0f
                    )
            );
    }
    
    public void RevertToOriginalColor()
    {
        RendererWithMaterial.material.SetColor
        (
            "_BaseColor",
            InitialColor
        );
    }
    
    
}
