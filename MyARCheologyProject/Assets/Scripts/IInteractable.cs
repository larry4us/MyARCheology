using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    // Start is called before the first frame update
    void OnInteract();

    // Update is called once per frame
    void StopInteract();
}
