using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivityManager : MonoBehaviour
{
    [SerializeField] private int queSizeSeconds = 15;
    [SerializeField] private int checksPerSecond = 3;
    [SerializeField] private bool triggerOnActivity; 

    private ActivityQueContainer container;

    private ITrackActivity tracker;
    private IHandleActivity handler;

    private bool playerIsActive;

    private void Awake()
    {
        tracker = GetComponent<ITrackActivity>();
        handler = GetComponent<IHandleActivity>();
    }

    private void Start()
    {
        tracker.Setup(queSizeSeconds * checksPerSecond, checksPerSecond, !triggerOnActivity);
        InvokeRepeating("CheckIsActive", 1, 1f / checksPerSecond);
        playerIsActive = !triggerOnActivity;
    }

    private void FixedUpdate()
    {
        if(!playerIsActive && !triggerOnActivity)
        {
            handler.OnNoActivityTracked();
        }
        else if(playerIsActive && triggerOnActivity)
        {
            handler.OnActivityTracked();
        }
    }

    void CheckIsActive()
    {
        tracker.UpdateTracking();
        playerIsActive = tracker.GetIsActive();
    }


}
