using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This interface handles the visual transition between the arrow being active and deactive.
public interface IAnimateActivation
{
    void Activate(GameObject go);
    void Deactivate(GameObject go);
    bool IsActivated();
}
