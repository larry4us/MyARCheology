using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            if (obj.TryGetComponent<Rigidbody>(out Rigidbody rb))
                rb.isKinematic = true;

            obj.transform.SetParent(availableSpot.transform, true);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;
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
