using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractor : MonoBehaviour, IInteractable
{
    private bool isHeld = false;

    public void OnInteract()
    {
        Debug.Log("Comecei a interagir...");
        PickOrDrop();
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

    private void PickOrDrop()
    {
        if (!isHeld)
        {
            Debug.Log("Segurando o objeto");
            HoldingManager.Instance.PickUp(gameObject);
            isHeld = true;
        } else
        {
            Debug.Log("Largando o objeto");
            HoldingManager.Instance.Drop();
            isHeld = false;
        }
    }
}
