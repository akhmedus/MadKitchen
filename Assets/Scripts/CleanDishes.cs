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

    }
}
