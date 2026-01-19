using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractor : MonoBehaviour, IInteractable
{
    private bool isHeld = false;
    private bool isLocked = false;
    private bool isScanned = false;

    [SerializeField] private SOObjectInfo objectInfo;

    [SerializeField] private float infoDisplayHeight = 2f;

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
        if (objectInfo == null || isScanned == false) return;

        var infoController = FindObjectOfType<ObjectInfoController>();

        if (infoController != null)
        {
            infoController.SetObjectInfo(objectInfo);
            infoController.SetVisible(true);

            infoController.transform.SetParent(transform);
            infoController.transform.localPosition = new Vector3(0, infoDisplayHeight, 0);
        }
    }

    private void HideObjectInfo()
    {
        var infoController = FindObjectOfType<ObjectInfoController>();

        if (infoController != null)
        {
            infoController.SetVisible(false);
            infoController.transform.SetParent(null);
        }
    }

    public void SetLocked(bool locked = true)
    {
        isLocked = locked;
    }

    public void SetScanned(bool scanned = true)
    {
        isScanned = scanned;
    }
}
