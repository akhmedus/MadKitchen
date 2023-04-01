using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectProperties
{
    public Transform GetNextCounterSpawn();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    public void CleanKitchenObject();

    public bool IsKitchenObject();
}
