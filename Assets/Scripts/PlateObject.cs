using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateObject : KitchenObject
{
    private List<KitchenObjects> _plateList;
    [SerializeField]
    private List<KitchenObjects> _burgerIngredients;
     

    public event EventHandler<AddedProductsEventArgs> AddProducts;
    public class AddedProductsEventArgs : EventArgs 
    {
        public KitchenObjects kitchenObjects;
    }


    private void Awake()
    {
        _plateList = new List<KitchenObjects>();
    }

    public bool TryAddProduct(KitchenObjects kitchenObjects) 
    {
        if (!_burgerIngredients.Contains(kitchenObjects)) 
        {
            
            return false;
        }
        if (_plateList.Contains(kitchenObjects))
        {
            return false;
        }
        else 
        { 
            _plateList.Add(kitchenObjects);
            
            AddProducts?.Invoke(this, new AddedProductsEventArgs
            {
                kitchenObjects = kitchenObjects
            });
            return true;
        }
    }

    public List<KitchenObjects> OnPlateList() 
    {
        return _plateList;
    }
}
