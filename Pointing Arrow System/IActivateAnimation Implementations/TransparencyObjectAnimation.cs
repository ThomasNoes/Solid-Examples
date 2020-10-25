using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyObjectAnimation : MonoBehaviour, IAnimateActivation
{
    [SerializeField] float duration = 1;
    [SerializeField] float opaqueAlpha = 1;
    [SerializeField] float transparentAlpha = 0.2f;

    private Material mat;

    public bool isActivated = true;

    public bool IsActivated()
    {
        return isActivated;
    }

    public void Deactivate(GameObject go)
    {
        SetMaterial(go);
        isActivated = false;
        TranspancyUp(go);

    }

    public void Activate(GameObject go)
    {
        SetMaterial(go);
        isActivated = true;
        TransparencyDown(go);
    }

    private void TranspancyUp(GameObject go)
    {
        StopCoroutine("TransparencyLerp");
        SetAlphaValue(mat, transparentAlpha);
        Debug.Log("making it transparent");
        StartCoroutine(TransparencyLerp(opaqueAlpha, transparentAlpha, duration, go));
    }
    private void TransparencyDown(GameObject go)
    {
        StopCoroutine("TransparencyLerp");
        SetAlphaValue(mat, opaqueAlpha);
        Debug.Log("");
        StartCoroutine(TransparencyLerp(transparentAlpha, opaqueAlpha, duration, go));
    }

    private IEnumerator TransparencyLerp(float from, float to, float totalDuration, GameObject go)
    {
        if (mat == null)
        {
            Debug.LogError("The gameobject's material is missing");
            yield return 0;
        }
        float currentDuration = totalDuration;
        float currentAlpha;

        while (currentDuration > 0)
        {
            float t = currentDuration / totalDuration;
            currentAlpha = Mathf.SmoothStep(from, to, t);
            SetAlphaValue(mat, currentAlpha);
            currentDuration -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return 0;
    }

    private void SetAlphaValue(Material mat, float alpha)
    {
        Color color = mat.color;
        color.a = alpha;
        mat.color = color;
    }

    private void SetMaterial(GameObject go)
    {
        this.mat = go.GetComponentInChildren<Renderer>().material;
        if (mat == null)
        {
            Debug.LogError("Mat was not found");
        }
    }

}