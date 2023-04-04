using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumpCounter : MainCounter
{
    public override void Interact(PlayerMovement playerMovement) 
    {
        if (playerMovement.IsKitchenObject()) 
        {
            playerMovement.GetKitchenObject().RemoveObject();
        }
    }
}
