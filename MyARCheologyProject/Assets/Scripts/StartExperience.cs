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
            //DebugFisica(obj);
            obj.transform.localScale = Vector3.Lerp(initialScale, targetScale, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            
            yield return null;
        }
    }
}
