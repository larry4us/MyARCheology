
using UnityEngine;

public class NeutralizeParentScale : MonoBehaviour
{
    [SerializeField] private Transform referenceParent; // geralmente: o Armario (ou o Spot)
    
    void LateUpdate()
    {
        if (!referenceParent) return;

        Vector3 s = referenceParent.lossyScale;

        // evita divisão por zero
        float ix = s.x != 0 ? 1f / s.x : 1f;
        float iy = s.y != 0 ? 1f / s.y : 1f;
        float iz = s.z != 0 ? 1f / s.z : 1f;

        transform.localScale = new Vector3(ix, iy, iz);
    }
}
