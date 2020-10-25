using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelaySetLayer : MonoBehaviour, IDelay
{
    [SerializeField] private string layerName;
    [SerializeField] private GameObject objectToSetLayerOn;

    public void Fire()
    {
        if (objectToSetLayerOn != null)
            objectToSetLayerOn.layer = ChangeToNewLayer(layerName);
        else
        {
            Debug.LogError("ObjectToSetLayerOn is not set in "+ gameObject.name);
        }
    }

    private int ChangeToNewLayer(string layerName)
    {
        if (layerName != "")
            return LayerMask.NameToLayer(layerName);
        else
            Debug.LogError("LayerName is not set in " + gameObject.name+". Object layer set to 'Default'");
        return 0;
    }

}
