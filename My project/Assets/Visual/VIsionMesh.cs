using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter))]
public class VisionMesh : MonoBehaviour
{
    public PlayerVision vision;
    public int rayCount = 120;

    Mesh mesh;

    void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    void LateUpdate()
    {
        float angle = -vision.viewAngle / 2f;
        float angleIncrease = vision.viewAngle / rayCount;

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        vertices.Add(Vector3.zero);

        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 dir = Quaternion.Euler(0, 0, angle) * vision.transform.up;
            Vector3 point = transform.position + dir * vision.viewDistance;

            RaycastHit2D hit = Physics2D.Raycast(vision.transform.position, dir, vision.viewDistance, vision.obstacleMask);
            if (hit.collider)
                point = hit.point;

            vertices.Add(transform.InverseTransformPoint(point));
            angle += angleIncrease;
        }

        for (int i = 1; i < vertices.Count - 1; i++)
        {
            triangles.Add(0);
            triangles.Add(i);
            triangles.Add(i + 1);
        }

        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateBounds();
    }
}