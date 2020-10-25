using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This interface handles the threshold for when the camera is determined
// to be far of and pointing the the opposite direction of the target.
public interface IActivateArrow
{
    bool ShouldActivate();
    bool IsInOppositeDirection();

    Transform GetPointingTarget();

}
