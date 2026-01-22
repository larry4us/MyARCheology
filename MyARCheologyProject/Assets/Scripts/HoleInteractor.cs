using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class HoleInteractor : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject hiddenObject;

    private bool objHasBeenDiscovered = false;

    void Start()
    {
        SetKinematic(hiddenObject, true);
    }

    private void SetKinematic(GameObject obj, bool boolean)
    {
        Rigidbody rigidBody = obj.GetComponent<Rigidbody>();
        if (rigidBody == null){
            Debug.LogWarning("Obj sem rigid body!");
            return;
        }

        rigidBody.isKinematic = boolean;
    }
    public void OnInteract()
    {   
        Debug.Log("OnInteract!");
        var hiddenObjectIsInteractable = hiddenObject.GetComponent<ObjectInteractor>() != null;
        if (hiddenObjectIsInteractable)
        {   
            if (!objHasBeenDiscovered) Cave();
        }
        else
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
    }

    private void Cave()
    {
        Debug.Log("Tentando cavar.");
        CavingSound();
        var objInteractor = hiddenObject.GetComponent<ObjectInteractor>();
        Fade(hiddenObject, 0, 1);
        SetKinematic(hiddenObject, false);
        objInteractor.OnInteract();
        objHasBeenDiscovered = true;
        gameObject.SetActive(false);
    }

    IEnumerator Fade(GameObject obj, float start, float end)
    {   
        Renderer rend = obj.GetComponent<Renderer>();
        Color color = rend.material.color;

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / 1f;
            color.a = Mathf.Lerp(start, end, t);
            rend.material.color = color;
            yield return new WaitForSeconds(2);
        }
    }

    private void CavingSound()
    {

    }
}
