using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CleanDishes : MonoBehaviour
{
    [SerializeField]
    private KitchenObjects _kitchenObjects;
    [SerializeField]
    private Transform _spawn;

    private KitchenObject _kitchenObject;

    [SerializeField]
    private CleanDishes _nextCleanDishes;
    public bool testing;

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T)) 
        {
            if (_kitchenObject != null) 
            {
                _kitchenObject.SetCleanDishes(_nextCleanDishes);
            }
        }
    }

    public Transform GetNextCounterSpawn() 
    {
        return _spawn;
    }

    public void SetKitchenObject(KitchenObject kitchenObject) 
    {
        this._kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() 
    {
        return _kitchenObject;
    }

    public void CleanKitchenObject() 
    {
        _kitchenObject = null;
    }

    public bool IsKitchenObject() 
    {
        return _kitchenObject != null;
    }

    public void Interact() 
    {
        if (_kitchenObject == null)
        {
            Transform objectTransform = Instantiate(_kitchenObjects._prefab, _spawn);
            objectTransform.GetComponent<KitchenObject>().SetCleanDishes(this);
        }
        else 
        {
            Debug.Log(_kitchenObject.GetCleanDishes());
        }
    }
}
