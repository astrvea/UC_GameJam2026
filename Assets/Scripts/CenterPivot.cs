using UnityEngine;

public class CenterPivot : MonoBehaviour
{
    [ContextMenu("Center Pivot")]
    public void Center()
    {
        // Calculate the combined bounds of all child renderers
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0) return;

        Bounds bounds = renderers[0].bounds;
        foreach (Renderer r in renderers)
            bounds.Encapsulate(r.bounds);

        Vector3 center = bounds.center;

        // Shift all children in the opposite direction
        foreach (Transform child in transform)
            child.position -= center;

        // Move the parent to where the center was
        transform.position = center;
    }
}