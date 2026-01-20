using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerController : MonoBehaviour
{

    [SerializeField] private SpotController spot;
    [SerializeField] private float scanDuration = 4f;
    [SerializeField] GameObject scanUI;
    private Animator scannerAnimator;

    void Start()
    {
        scannerAnimator = GetComponent<Animator>();
        scannerAnimator.SetBool("isScanning", false);
        //scanUI.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colidiu");
        if (collision.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            Debug.Log("Tentando colocar no spot");
            TryToPutOnSpot(collision.gameObject);
        }
    }

    private void TryToPutOnSpot(GameObject obj)
    {
        if (!spot.IsOccupied())
        {
            obj.transform.SetParent(spot.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;

            if (obj.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.isKinematic = true;
            }

            if (obj.TryGetComponent(out ObjectInteractor interactor))
            {
                StartCoroutine(StartScanning(interactor));
            }

        }
    }
    private IEnumerator StartScanning(ObjectInteractor interactor)
    {
        Debug.Log("Starting scan...");

        scannerAnimator.SetBool("isScanning", true);

        scanUI.SetActive(false);

        interactor.SetLocked(true);

        yield return new WaitForSeconds(scanDuration);
        Debug.Log("Scan complete!");

        scannerAnimator.SetBool("isScanning", false);

        scanUI.SetActive(true);

        interactor.SetLocked(false);
        interactor.SetScanned(true);
    }

}
