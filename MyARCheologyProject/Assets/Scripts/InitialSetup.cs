using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InitialSetup : MonoBehaviour
{

    [SerializeField] private float requiredArea;

    [SerializeField] private ARPlaneManager planeManager;

    [SerializeField] private GameObject startExperienceUI;

    [SerializeField] private StartExperience startExperience;

    [SerializeField] private Material floorMaterial;

    void OnEnable()
    {
        Debug.Log("Adicionando evento");
        planeManager.planesChanged += onPlanesUpdated;
    }
    void OnDisable()
    {
        Debug.Log("Removendo evento");
        planeManager.planesChanged -= onPlanesUpdated;
    }

    public void onClickStartExperience()
    {
        Debug.Log("Iniciando a experiência AR");
        startExperienceUI.SetActive(false);
        planeManager.enabled = false;

        var biggestPlane = GetBiggestPlane();
        ApplyFloorMaterial(biggestPlane);
        startExperience.OnStartExperience(biggestPlane);

    }

    private void onPlanesUpdated(ARPlanesChangedEventArgs args)
    {
        foreach(var plane in args.updated)
        {
            if (plane.extents.x * plane.extents.y >= requiredArea)
            {
                // Encontrei um plano
                Debug.Log("Encontramos o plano");
                startExperienceUI.SetActive(true);
            }
        }
    }

     private ARPlane GetBiggestPlane()
    {
        ARPlane biggestPlane = null;
        float biggestArea = 0f;

        foreach (var plane in planeManager.trackables)
        {
            float area = plane.extents.x * plane.extents.y;
            if (area > biggestArea)
            {
                biggestArea = area;
                biggestPlane = plane;
            }
        }

        return biggestPlane;
    }

    private void ApplyFloorMaterial(ARPlane plane)
{
    var renderer = plane.GetComponent<MeshRenderer>();
    if (renderer != null && floorMaterial != null)
    {
        renderer.material = floorMaterial;
    }

    // opcional: remover borda pontilhada
    var line = plane.GetComponent<LineRenderer>();
    if (line != null)
    {
        line.enabled = false;
    }
}

}
