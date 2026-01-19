using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StartExperience : MonoBehaviour
{
    [SerializeField] private GameObject cube;

        public void OnStartExperience(ARPlane plane)
    {
        var pos = plane.transform.TransformPoint(plane.center);
        var scene = Instantiate(cube, pos, Quaternion.identity);

        for (int i = 0; i < scene.transform.childCount; i++)
        {
            var child = scene.transform.GetChild(i).gameObject;
            StartCoroutine(ScaleUp(child, 0.5f));
        }
    }
    IEnumerator ScaleUp(GameObject obj, float duration)
    {   

        Vector3 targetScale = obj.transform.localScale;
        Vector3 initialScale = targetScale * 0.01f; //1% do tamanho original

        float elapsedTime = 0f;

        obj.transform.localScale = initialScale;

        while (elapsedTime < duration)
        {
            DebugFisica(obj);
            obj.transform.localScale = Vector3.Lerp(initialScale, targetScale, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
    }

    void DebugFisica(GameObject obj)
{
    Debug.Log($"--- DEBUG FÍSICA: {obj.name} ---");

    // Transform
    Debug.Log($"Scale (local): {obj.transform.localScale}");
    Debug.Log($"Scale (lossy): {obj.transform.lossyScale}");
    Debug.Log($"Position: {obj.transform.position}");

    // Rigidbody
    var rb = obj.GetComponent<Rigidbody>();
    if (rb != null)
    {
        Debug.Log($"Rigidbody | Mass: {rb.mass}, UseGravity: {rb.useGravity}, IsKinematic: {rb.isKinematic}");
        Debug.Log($"Velocity: {rb.velocity}");
    }
    else
    {
        Debug.Log("Rigidbody: NÃO EXISTE");
    }

    // BoxCollider
    var box = obj.GetComponent<BoxCollider>();
    if (box != null)
    {
        Vector3 worldSize = Vector3.Scale(box.size, obj.transform.lossyScale);

        Debug.Log($"BoxCollider | Size (local): {box.size}");
        Debug.Log($"BoxCollider | Size (world): {worldSize}");
        Debug.Log($"BoxCollider | Center: {box.center}");
    }
    else
    {
        Debug.Log("BoxCollider: NÃO EXISTE");
    }
}

}
