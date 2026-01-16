using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StartExperience : MonoBehaviour
{

    [SerializeField] private float requiredArea;

    [SerializeField] private ARPlaneManager planeManager;

    [SerializeField] private GameObject startExperienceUI;

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

        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
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
}
