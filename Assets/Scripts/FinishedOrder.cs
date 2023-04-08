using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedOrder : MonoBehaviour
{
    [SerializeField]
    private PlateObject plateObject;

    [Serializable]
    public struct KitchenGameObjects 
    {
        public KitchenObjects kitchenObjects;
        public GameObject gameObject;
    }

    [SerializeField]
    private List<KitchenGameObjects> kitchenGameObjectsList;

    private void Start()
    {
        plateObject.AddProducts += PlateObject_AddProducts;

        foreach (var kitchenGameObject in kitchenGameObjectsList)
        {
            kitchenGameObject.gameObject.SetActive(false);
        }   
    }

    private void PlateObject_AddProducts(object sender, PlateObject.AddedProductsEventArgs e)
    {
        foreach (var kitchenGameObject in kitchenGameObjectsList) 
        {
            if (kitchenGameObject.kitchenObjects == e.kitchenObjects) 
            {
                kitchenGameObject.gameObject.SetActive(true);  
            }
        }
    }
}
