using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenAngleActivator : MonoBehaviour, IActivateArrow
{

    Transform camera;
    [SerializeField] private Transform target;
    [SerializeField] private float activationLimit, oppositeLimit;

    private Vector3 cameraForward;
    private Vector3 cam2Target;

    private float currentAngle;

    private void Awake()
    {
        camera = Camera.main.transform;

        if (!target) // if the target is not set in the inspector, try to find it in the hierachy
            target = GameObject.Find("Target").transform;
        if (!target)
            Debug.LogError("BetweenAngleActivator is missing its Target");
    }

    public bool ShouldActivate()
    {
        return CompareCurrentAngleWith(activationLimit); 
    }

    public bool IsInOppositeDirection()
    {
        return CompareCurrentAngleWith(oppositeLimit);
    }

    private bool CompareCurrentAngleWith(float limit)
    {
        UpdateCurrentAngle();
        if (currentAngle > limit)
        {
            return true;
        }
        return false;
    }

    public Transform GetPointingTarget()
    {
        return target;
    }

    private void UpdateCurrentAngle()
    {
        SetVectors();
        currentAngle = GetAngleBetween(cam2Target, cameraForward);
    }

    private void SetVectors()
    {
        if (camera != null)
        {
            Debug.LogError("BetweenAngleActivator is missing camera");
            return;
        }
        if (target != null)
        {
            Debug.LogError("BetweenAngleActivator is missing target");
            return;
        }
        cameraForward = camera.forward;
        cam2Target = target.position - camera.position;
    }

    private float GetAngleBetween(Vector3 from, Vector3 to)
    {
        return Vector3.Angle(from, to);
    }
}
