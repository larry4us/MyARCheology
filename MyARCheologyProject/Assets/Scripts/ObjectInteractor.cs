using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractor : MonoBehaviour, IInteractable
{
    private bool isHeld = false;

    [SerializeField] private SOObjectInfo objectInfo;

    [SerializeField] private float objectInfoHeight = 0.3f;

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
            //infoController.transform.SetParent(transform);
            
            // parentear mantendo mundo (inclui escala)
    infoController.transform.SetParent(transform, true);

    // posicionar acima do objeto em WORLD (não local)
    var rend = GetComponentInChildren<Renderer>();
    Vector3 topo = rend != null ? rend.bounds.max : transform.position;
    infoController.transform.position = topo + Vector3.up * objectInfoHeight;
        }
    }

     private void HideObjectInfo()
    {
        var infoController = FindObjectOfType<ObjectInfoController>();

        if (infoController != null)
        {
            //infoController.SetVisible(false);
            infoController.transform.SetParent(null);
        }
    }
}
