using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaterialCleaner : MonoBehaviour
{
    [SerializeField] private Material newCleanMaterial;

    [SerializeField] private MeshRenderer meshRenderer;

    public void Clean()
    {
        if (newCleanMaterial != null && meshRenderer != null)
        {
            meshRenderer.material = newCleanMaterial;
        } else
        {
            Debug.LogWarning("Erro no material cleaner: algum dos parametros é null");
        }
    }
}
