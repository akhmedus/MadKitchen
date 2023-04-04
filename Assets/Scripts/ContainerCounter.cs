using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : MainCounter 
{
    [SerializeField]
    private KitchenObjects _kitchenObjects;

    public event EventHandler _playerInteraction;

    public override void Interact(PlayerMovement playerMovement)
    {
        var playerInteract = playerMovement.IsKitchenObject();

        if (!playerInteract) 
        {
            var objectTransform = Instantiate(_kitchenObjects._prefab);
            objectTransform.GetComponent<KitchenObject>().SetObjectProperties(playerMovement);

            _playerInteraction?.Invoke(this, EventArgs.Empty);
        }
        
    }
}
