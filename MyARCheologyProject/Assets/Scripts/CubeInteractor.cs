using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractor : MonoBehaviour, IInteractable
{
    private bool isHeld = false;

    [SerializeField] private SOObjectInfo objectInfo;

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
       if (HoldingManager.Instance.TryPickUp(gameObject))
        {
            isHeld = true;
            ShowObjectInfo();
        }
        else
        {
            HoldingManager.Instance.Drop();
            isHeld = false;
            HideObjectInfo();
        }
    }

    private void ShowObjectInfo()
    {
        if (objectInfo == null) return;

        var infoController = FindObjectOfType<ObjectInfoController>();

        if (infoController != null)
        {
            infoController.SetObjectInfo(objectInfo);
            infoController.SetVisible(true);
            infoController.transform.SetParent(transform);
        }
    }

     private void HideObjectInfo()
    {
        var infoController = FindObjectOfType<ObjectInfoController>();

        if (infoController != null)
        {
            infoController.SetVisible(false);
            //infoController.transform.SetParent(null);
        }
    }
}
