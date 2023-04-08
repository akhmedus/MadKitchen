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
                if (playerMovement.GetKitchenObject().TryGetPlate(out PlateObject plateObject))
                {
                    if (plateObject.TryAddProduct(GetKitchenObject().GetKitchenObjects()))
                    {
                        GetKitchenObject().RemoveObject();
                    }
                }
                else 
                {
                    if (GetKitchenObject().TryGetPlate(out plateObject)) 
                    {
                        if (plateObject.TryAddProduct(playerMovement.GetKitchenObject().GetKitchenObjects()))
                        {
                           playerMovement.GetKitchenObject().RemoveObject();
                        }
                    }
                }
            }
            else 
            {
                GetKitchenObject().SetObjectProperties(playerMovement);
            }
        }
    }
}
