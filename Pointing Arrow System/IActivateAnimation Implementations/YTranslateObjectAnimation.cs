using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YTranslateObjectAnimation : MonoBehaviour, IAnimateActivation
{
    [SerializeField] float duration;

    public bool isActivated = true;

    private Vector3 LocalActivatePosition;
    private Vector3 LocalDeactivatePosition;

    private void Awake()
    {
        Transform t = transform.GetChild(0);

        LocalActivatePosition = t.localPosition;
        LocalDeactivatePosition = t.localPosition + transform.up;
    }

    public bool IsActivated()
    {
        return isActivated;
    }

    public void Activate(GameObject go)
    {
        isActivated = true; //Update the state
        MoveDown(go); //Initiate the Move transition

    }

    public void Deactivate(GameObject go)
    {
        isActivated = false;
        MoveUp(go);
    }

    private void MoveUp(GameObject go)
    {
        StopCoroutine("Move"); //Stop any Move-coroutine currently running
        go.transform.localPosition = LocalActivatePosition; // Set the localPosition of the gameobject go before starting the coroutine
        StartCoroutine(Move(LocalDeactivatePosition, LocalActivatePosition, duration, go));
    }
    private void MoveDown(GameObject go)
    {
        StopCoroutine("Move");
        go.transform.localPosition = LocalDeactivatePosition;
        StartCoroutine(Move(LocalActivatePosition, LocalDeactivatePosition, duration, go));
    }

    private IEnumerator Move(Vector3 from, Vector3 to, float totalDuration, GameObject go)
    {
        float currentDuration = totalDuration;
        Vector3 currentPosition;

        while (currentDuration > 0)
        {
            float t = currentDuration / totalDuration;
            currentPosition = Vector3.Lerp(from, to, t); //The lerping between the from and to Vector positions
            go.transform.localPosition = currentPosition;
            currentDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}
