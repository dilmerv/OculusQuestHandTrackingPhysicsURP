using DilmerGames.Core.Singletons;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(VisualEffect))]
public class VFXManager : Singleton<VFXManager>
{
    private VisualEffect visualEffect;

    [SerializeField, Range(1f,10f)]
    private float drag = 1f;
    private float dragMin = 1f;
    private float dragMax = 10f;

    [SerializeField, Range(1.82f,7.95f)]
    private float intensity = 1.82f;
    private float intensityMin = 1.82f;
    private float intensityMax = 7.95f;

    [SerializeField, Range(0.01f,0.15f)]
    private float radius = 0.01f;
    private float radiusMin = 0.01f;
    private float radiusMax = 0.15f;

    private void Awake() 
    {
        visualEffect = GetComponent<VisualEffect>();
    }

    public void MaxOutEffect(string effectName)
    {
        switch(effectName)
        {
            case "Drag":
            visualEffect.SetFloat("Drag", dragMax);
            visualEffect.SetFloat("Intensity", intensityMin);
            visualEffect.SetFloat("Radius", radiusMin);
            break;
            case "Intensity":
            visualEffect.SetFloat("Drag", dragMin);
            visualEffect.SetFloat("Intensity", intensityMax);
            visualEffect.SetFloat("Radius", radiusMin);
            break;
            case "Radius":
            visualEffect.SetFloat("Drag", dragMin);
            visualEffect.SetFloat("Intensity", intensityMin);
            visualEffect.SetFloat("Radius", radiusMax);
            break;
            case "Reset":
            visualEffect.SetFloat("Drag", dragMin);
            visualEffect.SetFloat("Intensity", intensityMin);
            visualEffect.SetFloat("Radius", radiusMin);
            break;
        }
    }
}
