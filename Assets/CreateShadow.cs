using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShadow : MonoBehaviour
{
    // we want to make a 2d convex hull from the vertices of the 3d model raycasted onto the wall
    public GameObject obj;
    public GameObject wall;

    void Start()
    {
        obj = this.gameObject;

        ProjectSilhouette();
    }

    void ProjectSilhouette()
    {
        // Get the mesh filter component from the object
        MeshFilter meshFilter = obj.GetComponent<MeshFilter>();

        if (meshFilter != null)
        {
            Mesh mesh = meshFilter.mesh;

            // Get the vertices of the mesh
            Vector3[] vertices = mesh.vertices;
            List<Vector2> projectedPoints = new List<Vector2>();

            foreach (Vector3 vertex in vertices)
            {
                Vector2 projectedPoint = new Vector2(vertex.y, vertex.z);
                projectedPoints.Add(projectedPoint);
            }
        }
    }


}
