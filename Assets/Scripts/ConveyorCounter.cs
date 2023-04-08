using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorCounter : MainCounter
{

    public override void Interact(PlayerMovement playerMovement)
    {
        if (playerMovement.IsKitchenObject()) 
        {
            if (playerMovement.GetKitchenObject().TryGetPlate(out PlateObject plate)) 
            {
                playerMovement.GetKitchenObject().RemoveObject();
            }
        }
    }
}
