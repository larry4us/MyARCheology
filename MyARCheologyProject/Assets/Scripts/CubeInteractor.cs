using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractor : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        Debug.Log("Comecei a interagir...");
    }

    public void StopInteract()
    {
        Debug.Log("Parei de interagir.");
    }

    // Update is called once per frame
    void Update()
    {
        if(InputHandler.TryRayCastHit(out RaycastHit hitObject)){
            if (hitObject.transform == transform)
            {
                OnInteract();
            }
        }
    }
}
