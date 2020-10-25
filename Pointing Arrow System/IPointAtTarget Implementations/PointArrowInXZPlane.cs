using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This implementation points the arrow at the target and project the direction on the the world space XZ plane 
public class PointArrowInXZPlane : MonoBehaviour, IPointAtTarget
{

    private Vector3 arrow2target;
    private Vector3 velocity = Vector3.zero; // Velocity used for smoothing the rotation of the arrow

    public void PointTowards(Transform t)
    {
        arrow2target = t.position - transform.position;

        ProjectOntoCamPlane();

        SmoothRotate();
    }

    public void PointHorizontalTowards(Transform t) // Since the arrow is along the XZ plane, it is already horinzontal. Therefore, I forward to call to PointTowards().
    {
        PointTowards(t);
    }

    private void ProjectOntoCamPlane()
    {
        arrow2target = Vector3.ProjectOnPlane(arrow2target, Vector3.up); // Projecting the arrow onto the worldspace XZ plane with the vector3.up 
    }

    private void SmoothRotate()
    {
        transform.forward = Vector3.SmoothDamp(transform.forward, arrow2target, ref velocity, 0.3f);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
