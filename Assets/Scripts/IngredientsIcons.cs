using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsIcons : MonoBehaviour
{
    [SerializeField]
    private PlateObject _plateObject;
    [SerializeField]
    private Transform _icons;

    private void Awake()
    {
        _icons.gameObject.SetActive(false);
    }
    private void Start()
    {
        _plateObject.AddProducts += _plateObject_AddProducts;
    }


    private void _plateObject_AddProducts(object sender, PlateObject.AddedProductsEventArgs e)
    {
        ShowIngredients();
    }

    private void ShowIngredients()
    {
        foreach (Transform child in transform) 
        {
            if (child == _icons)
            {
                continue;
            }
            Destroy(child.gameObject);
        }

        foreach (var kitchenObjects in _plateObject.OnPlateList()) 
        {
            var icon = Instantiate(_icons, transform);
            icon.gameObject.SetActive(true);
            icon.GetComponent<IconUI>().SetIconSprite(kitchenObjects);
        }
    }
}
