using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use this manager if you want to update the the arrows orientation, and use the IAnimateActivation interface
// to provide feedback to the player based on how well the camera is looking at the arrow's target.

public class AlwaysGuidingArrowManager : MonoBehaviour
{
    IActivateArrow activator;
    IAnimateActivation animator;
    IPointAtTarget arrowPointer;

    private void Awake()
    {
        activator = GetComponent<IActivateArrow>();
        animator = GetComponent<IAnimateActivation>();

        arrowPointer = GetComponent<IPointAtTarget>();
        if (arrowPointer == null)
            arrowPointer = GetComponentInChildren<IPointAtTarget>();
    }


    // Update is called once per frame
    void Update()
    {
        if (activator.IsInOppositeDirection()) // Based on the whether the camera is pointing in the opposite direction of the target, choose the preferred arrowPointer behaviour
            arrowPointer.PointHorizontalTowards(activator.GetPointingTarget());
        else
            arrowPointer.PointTowards(activator.GetPointingTarget());
        
        if (activator.ShouldActivate()) // Start
        {
            if (!animator.IsActivated())
                animator.Activate(arrowPointer.GetGameObject());
        }
        else
        {
            if (animator.IsActivated())
                animator.Deactivate(arrowPointer.GetGameObject());
        }
    }
}

