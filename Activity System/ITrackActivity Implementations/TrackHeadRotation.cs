using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackHeadRotation : MonoBehaviour, ITrackActivity
{
    [SerializeField] private float thresholdAnglePerSecond = 0.01f;

    private ActivityQueContainer container;
    private int length;
    private int checksPerSecond;

    private Transform camera;

    private void Awake()
    {
        camera = Camera.main.transform;
    }

    public void Setup(int length, int checksPerSecond, bool startValue)
    {
        this.length = length;
        this.checksPerSecond = checksPerSecond;

        container = new ActivityQueContainer();
        container.InstantiateQue(length, startValue);
    }

    public bool GetIsActive()
    {
        for (int i = container.activityQue.Count - 1; i >= 0; i--)
        {
            if (container.activityQue.ToArray()[i] == false)
            {
                return true;
            }
        }

        return false;
    }

    public void UpdateTracking()
    {
        Queue<bool> que = container.activityQue;
        if (!Input.GetButton("Fire1"))
        {
            Quaternion currentRead = camera.rotation;

            //makes sure that we don't overflow the que
            if (que.Count >= length)
            {
                que.Dequeue();
            }
            if (container.lastRead == null)
                que.Enqueue(false);

            if (Quaternion.Angle(container.lastRead, currentRead) >= thresholdAnglePerSecond / checksPerSecond)
            {
                que.Enqueue(false);
            }
            else
            {
                que.Enqueue(true);
            }

            container.lastRead = currentRead;
        }
        else
        {
            que.Enqueue(false);
        }
    }
        
}
