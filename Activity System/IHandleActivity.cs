using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandleActivity
{
    void OnNoActivityTracked();
    void OnActivityTracked();
}
