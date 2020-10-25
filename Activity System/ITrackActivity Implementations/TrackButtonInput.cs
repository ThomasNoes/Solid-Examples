using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Use this to determine player/user activity through button input
public class TrackButtonInput : MonoBehaviour, ITrackActivity
{

    private bool isActive;

    private void Start()
    {
        isActive = false;
    }

    public void Setup(int length, int checksPerSecond, bool startValue)
    {
        // Not necessary when no data container is needed for tracking.
        // the activity is tracked in the update loop instead.
    }

    private void Update()
    {
        if (Input.  GetButtonDown("Fire1")) // For the project that this was using in, there was only one input.
        {
            SetIsActiveTrue();
        }
    }

    private void SetIsActiveTrue()
    {
        isActive = true;
    }

    public bool GetIsActive()
    {
        return isActive;
    }

    public void UpdateTracking()
    {
        //hehe
        //no queue data container needs to be updated when we use button input
    }


}
