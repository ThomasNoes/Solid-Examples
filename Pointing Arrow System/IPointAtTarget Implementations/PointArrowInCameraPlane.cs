using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use This implementation if you want the arrow to be projected on the camera's local space XY plane.
public class PointArrowInCameraPlane : MonoBehaviour, IPointAtTarget
{
    Transform camera;

    Vector3 arrow2target;

    [SerializeField] private float distanceToCam;

    private Vector3 velocity = Vector3.zero; // Used for smoothing the rotation

    private void Awake()
    {
        camera = Camera.main.transform;
        SetZPosition();
    }

    public void PointTowards(Transform t)
    {
        arrow2target =  t.position - transform.position;

        ProjectOntoCamPlane();

        SmoothRotate();
    }

    public void PointHorizontalTowards(Transform t)
    {
        arrow2target = t.position - transform.position;

        ProjectOntoCamHorizontal();

        SmoothRotate();

    }
    private void ProjectOntoCamHorizontal()
    {
        arrow2target = Vector3.Project(arrow2target, camera.right);
    }

    private void ProjectOntoCamPlane()
    {
        arrow2target = Vector3.ProjectOnPlane(arrow2target, camera.forward);
    }

    private void SmoothRotate()
    {
        transform.forward = Vector3.SmoothDamp(transform.forward, arrow2target, ref velocity, 0.3f);
    }

    private void SetZPosition()
    {
        transform.localPosition = 
            new Vector3(transform.localPosition.x, 
            transform.localPosition.y, 
            distanceToCam);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
        
