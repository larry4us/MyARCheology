using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetController : MonoBehaviour
{

    [SerializeField] private List<SpotController> spots;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            // Poder guardar no armário
            TryToPutOnCabinet(collision.gameObject);
        }
    }

    private void TryToPutOnCabinet(GameObject obj)
    {
        if (GetAvailableSpot() is SpotController availableSpot)
    {
        // guarda escala visual atual (no mundo)
        Vector3 worldScale = obj.transform.lossyScale;

        obj.transform.SetParent(availableSpot.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        // tenta manter o mesmo tamanho visual após virar filho
        Vector3 parentScale = availableSpot.transform.lossyScale;
        obj.transform.localScale = new Vector3(
            worldScale.x / parentScale.x,
            worldScale.y / parentScale.y,
            worldScale.z / parentScale.z
        );

        if (obj.TryGetComponent<Rigidbody>(out Rigidbody rb))
            rb.isKinematic = true;
    }
    }

    private SpotController GetAvailableSpot()
    {
        foreach (SpotController spot in spots)
        {
            if (!spot.IsOccupied())
            {
                return spot;
            }
        }
        
        return null;
    }
}
