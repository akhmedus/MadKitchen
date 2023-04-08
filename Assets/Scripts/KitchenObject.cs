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

    public void RemoveObject() 
    {
        _objectProperties.CleanKitchenObject();

        Destroy(gameObject);
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjects objects, IObjectProperties properties) 
    {
        var objectTransform = Instantiate(objects._prefab);
        var kitchenObject = objectTransform.GetComponent<KitchenObject>();
        kitchenObject.SetObjectProperties(properties);

        return kitchenObject;
    }

    public bool TryGetPlate(out PlateObject plateObject) 
    {
        if (this is PlateObject)
        {
            plateObject = (PlateObject)this;
            return true;
        }
        else 
        {
            plateObject = null;
            return false;
        }
    }
}
