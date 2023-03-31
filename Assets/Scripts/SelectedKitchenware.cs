using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedKitchenware : MonoBehaviour
{
    [SerializeField]
    private CleanDishes _cleanDishes;

    public GameObject _gameObject;

    private void Start()
    {
        PlayerMovement.PMInstance._selectedKitchenwareEvent += PMInstance__selectedKitchenwareEvent;
    }

    private void PMInstance__selectedKitchenwareEvent(object sender, PlayerMovement.SelectedKitchenwareEvent e)
    {
        if (e.selectedKitchenware == _cleanDishes)
        {
            Show();
        }
        else 
        {
            Hide();
        }
    }

    private void Show()
    {
        _gameObject.SetActive(true);
    }
    private void Hide()
    {
        _gameObject.SetActive(false);
    }
}
