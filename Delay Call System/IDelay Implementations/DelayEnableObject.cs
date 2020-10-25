using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayEnableObject : MonoBehaviour, IDelay
{
    [SerializeField] private GameObject disabledObject;


    private void Start()
    {
        if (disabledObject != null)
            disabledObject.SetActive(false);
        else
            Debug.LogError("DisabledObject is not set on " + gameObject.name);
    }

    public void Fire()
    {
        disabledObject.SetActive(true);
    }

    public void SetDisabledObject(GameObject go)
    {
        this.disabledObject = go;
    }

}
