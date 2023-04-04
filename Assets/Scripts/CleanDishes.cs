using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CleanDishes : MainCounter 
{
    [SerializeField]
    private KitchenObjects _kitchenObjects;

    public override void Interact(PlayerMovement playerMovement) 
    {
        var kitchenObject = IsKitchenObject();
        var playerInteract = playerMovement.IsKitchenObject();

        if (!kitchenObject)
        {
            if (playerInteract)
            {
                playerMovement.GetKitchenObject().SetObjectProperties(this);
            }
            else
            {

            }
        }
        else 
        {
            if (playerInteract)
            {

            }
            else 
            {
                GetKitchenObject().SetObjectProperties(playerMovement);
            }
        }
    }
}
