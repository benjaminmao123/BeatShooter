using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static Ray CreateRay()
    {
        return new Ray();
    }

    public static Ray CreateRay(Vector3 origin, Vector3 direction)
    {
        return new Ray(origin, direction);
    }

    public static bool RaycastCheck(out RaycastHit hit, Ray ray, float maximumLength)
    {
        if (Physics.Raycast(ray.origin, ray.direction, out hit, maximumLength))
        {
            return true;
        }

        return false;
    }

    public static LineRenderer CreateLine(Vector3 position, float startWidth, float endWidth)
    {
        GameObject line = new GameObject();
        line.transform.position = position;
        line.AddComponent<LineRenderer>();

        LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, position);
        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = endWidth;

        return lineRenderer;
    }

    public static void FaceTarget(Transform transform, Transform target)
    {
        transform.LookAt(target);
    }
}
