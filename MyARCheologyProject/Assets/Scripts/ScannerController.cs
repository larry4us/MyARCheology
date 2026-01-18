using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerController : MonoBehaviour
{

    [SerializeField] private SpotController spot;
    [SerializeField] private float scanDuration = 4f;
    [SerializeField] GameObject scamUI;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();  
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
            Debug.Log("Conseguiu colocar no spot");
            obj.transform.SetParent(spot.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localRotation = Quaternion.identity;

            if (obj.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.isKinematic = true;
            }

            StartCoroutine(StartScanning());
        }
    }

     private IEnumerator StartScanning()
    {
       Debug.Log("Scaneando...");

       animator.SetBool("isScanning", true);

       yield return new WaitForSeconds(scanDuration);

       Debug.Log("Scan complete!");

       animator.SetBool("isScanning", false);
    }

}
