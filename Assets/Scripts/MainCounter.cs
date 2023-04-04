using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCounter : MonoBehaviour, IObjectProperties 
{
    [SerializeField]
    private Transform _spawn;

    private KitchenObject _kitchenObject;

    public virtual void Interact(PlayerMovement playerMovement) { }

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

    public virtual void SecondInteract(PlayerMovement playerMovement) { }
}
