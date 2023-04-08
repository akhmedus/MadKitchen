using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : MainCounter
{
    public event EventHandler PlateSpawned;
    public event EventHandler PlateRemoved;

    [SerializeField]
    private KitchenObjects _plate;

    private float _timer;
    private float _maxTime = 4f;

    private int _plates;
    private float _maxPlates = 4;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _maxTime) 
        {
            _timer = 0;

            if (_plates < _maxPlates) 
            {
                _plates++;
                PlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(PlayerMovement playerMovement)
    {
        if (!playerMovement.IsKitchenObject()) 
        {
            if (_plates > 0) 
            {
                _plates--;

                KitchenObject.SpawnKitchenObject(_plate, playerMovement);

                PlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
