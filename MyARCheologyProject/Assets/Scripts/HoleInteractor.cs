using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleInteractor : MonoBehaviour, IInteractable
{   
    [SerializeField] private GameObject hiddenObject;

    public void OnInteract()
    {
        var hiddenObjectIsInteractable = hiddenObject.GetComponent<ObjectInteractor>() != null;
        if (hiddenObjectIsInteractable)
        {
            Cave();
        } else
        {
            Debug.Log("O objeto nao é Interactable.");
        }
    }

    public void StopInteract()
    {
        
    }

    void Update()
    {
        if (InputHandler.TryRayCastHit(out RaycastHit hitObject))
        {
            if (hitObject.transform == transform)
            {
                OnInteract();
            }
        }
        {
            Debug.Log("RayCast acertando outra coisa");
        }
    }

    private void Cave()
    {
        Debug.Log("Tentando cavar.");
        CavingSound();
        var objInteractor = hiddenObject.GetComponent<ObjectInteractor>();
        objInteractor.OnInteract();
    }

    private void CavingSound()
    {
        
    }
}
