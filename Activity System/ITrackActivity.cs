using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrackActivity
{
    bool GetIsActive();
    void Setup(int length, int checksPerSecond, bool startValue);
    void UpdateTracking();

}
