using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField]
    private KitchenObjects _kitchenObjects;

    private IObjectProperties _objectProperties;

    public void SetObjectProperties(IObjectProperties objectProperties) 
    {
        if (_objectProperties != null) 
        {
            _objectProperties.CleanKitchenObject();
        }

        _objectProperties = objectProperties;

        if (objectProperties.IsKitchenObject()) 
        {
            Debug.Log("Already has a KitchenObject!!!");
        }

        objectProperties.SetKitchenObject(this);

        transform.parent = objectProperties.GetNextCounterSpawn();
        transform.localPosition = Vector3.zero;
    }
    public IObjectProperties GetObjectProperties() 
    {
        return _objectProperties;
    }
    public KitchenObjects GetKitchenObjects() 
    {
        return _kitchenObjects;
    }
}
