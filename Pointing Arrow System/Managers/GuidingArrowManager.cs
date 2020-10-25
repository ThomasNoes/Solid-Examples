using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use this manager if you only want the arrow to be visible if the camera's 
// forward vector is too far to the direction on the target the arrow should point at.
public class GuidingArrowManager : MonoBehaviour
{
    IActivateArrow activator; 
    IAnimateActivation animator;
    IPointAtTarget arrowPointer;

    private void Awake()
    {
        //finding the the implementation of the interfaces
        arrowPointer = GetComponent<IPointAtTarget>();
        if (arrowPointer == null)
            arrowPointer = GetComponentInChildren<IPointAtTarget>();

        activator = GetComponent<IActivateArrow>();
        animator = GetComponent<IAnimateActivation>();

    }

    void Update()
    {
        if (activator.ShouldActivate()) // Check if the arrow should be activated.
        {
            if (!animator.IsActivated()) // If the arrow should be activate, check if the animator is active as well.
                animator.Activate(arrowPointer.GetGameObject());

            if (activator.IsInOppositeDirection()) // Determine how the arrowPointer should point the arrow based on the if the camera is pointing in the opposite direction of the target.
                arrowPointer.PointHorizontalTowards(activator.GetPointingTarget());
            else
                arrowPointer.PointTowards(activator.GetPointingTarget());
        }   
        else
        {
            if (animator.IsActivated()) // If the activator should not be active, deactivate the animator if it is set to active.
                animator.Deactivate(arrowPointer.GetGameObject());
        }
    }
}
