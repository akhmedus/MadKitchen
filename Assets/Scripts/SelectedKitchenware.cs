using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedKitchenware : MonoBehaviour
{
    [SerializeField]
    private MainCounter _mainCounter;

    public GameObject[] _gameObjects;

    private void Start()
    {
        PlayerMovement.PMInstance._selectedKitchenwareEvent += PMInstance__selectedKitchenwareEvent;
    }

    private void PMInstance__selectedKitchenwareEvent(object sender, PlayerMovement.SelectedKitchenwareEvent e)
    {
        if (e.selectedCounter == _mainCounter)
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
        foreach (var gameObject in _gameObjects) 
        {
            gameObject.SetActive(true);
        }
    }
    private void Hide()
    {
        foreach (var gameObject in _gameObjects)
        {
            gameObject.SetActive(false);
        }
    }
}
