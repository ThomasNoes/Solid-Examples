using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This interface handles the pointing behaviour including 
// calculating and setting the rotation of the arrow object.
public interface IPointAtTarget
{
    void PointTowards(Transform t);
    void PointHorizontalTowards(Transform t);
    GameObject GetGameObject();
}