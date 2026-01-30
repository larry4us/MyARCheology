using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaterialCleaner : MonoBehaviour
{
    [SerializeField] private Material newCleanMaterial;

    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] private GameObject vfxDirtEffect;

    public void Clean()
    {
        if (newCleanMaterial != null && meshRenderer != null)
        {
            meshRenderer.material = newCleanMaterial;
            removeDirtEffect();
        } else
        {
            Debug.LogWarning("Erro no material cleaner: algum dos parametros é null");
        }
    }

    private void removeDirtEffect()
    {
        if (vfxDirtEffect != null)
        {
            vfxDirtEffect.SetActive(false);
        } else
        {
            Debug.Log("O objeto não possuia Dirt Effect");
        }
    }
}
