using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObjectAnimation : MonoBehaviour, IAnimateActivation
{
    [SerializeField] private float duration = 1;

    [SerializeField] private bool isActivated = true;


    public bool IsActivated()
    {
        return isActivated;
    }

    public void Activate(GameObject go)
    {
        isActivated = true; //Update the state
        ScaleUp(go); // Initiate the scale up transition
    }

    public void Deactivate(GameObject go)
    {
        isActivated = false;
        ScaleDown(go);
    }

    private void ScaleUp(GameObject go)
    {
        StopCoroutine("Scale"); // Stop any coroutine currently running.
        go.transform.localScale = Vector3.zero; //Set localscale before scaling up the gameobject go.
        StartCoroutine(Scale(1, 0, duration, go));
    }
    private void ScaleDown(GameObject go)
    {
        StopCoroutine("Scale");
        go.transform.localScale = Vector3.one;
        StartCoroutine(Scale(0, 1, duration, go));
    }

    private IEnumerator Scale(float from, float to, float totalDuration, GameObject go)
    {
        float currentDuration = totalDuration;
        float currentScale;

        while (currentDuration > 0) //run loop for the totalDuration
        {
            float t = currentDuration / totalDuration;
            currentScale = Mathf.SmoothStep(from, to, t); //lerping the scale between from and to values.
            go.transform.localScale = Vector3.one * currentScale; 
            currentDuration -= Time.deltaTime; 
            yield return new WaitForEndOfFrame();
        }
    }

}