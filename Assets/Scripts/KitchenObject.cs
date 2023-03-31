using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField]
    private KitchenObjects _kitchenObjects;

    private CleanDishes _cleanDishes;

    public void SetCleanDishes(CleanDishes cleanDishes) 
    {
        if (_cleanDishes != null) 
        {
            _cleanDishes.CleanKitchenObject();
        }

        _cleanDishes = cleanDishes;

        if (cleanDishes.IsKitchenObject()) 
        {
            Debug.Log("Already has a KitchenObject!!!");
        }

        cleanDishes.SetKitchenObject(this);

        transform.parent = cleanDishes.GetNextCounterSpawn();
        transform.localPosition = Vector3.zero;
    }
    public CleanDishes GetCleanDishes() 
    {
        return _cleanDishes;
    }
    public KitchenObjects GetKitchenObjects() 
    {
        return _kitchenObjects;
    }
}
