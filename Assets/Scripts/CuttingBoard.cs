using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CuttingBoard : MainCounter, IObjectProgress
{
    [SerializeField]
    private CuttingObjects[] _cuttingObjects;

    [SerializeField]
    private bool _interact = false;

    private int _cuttingProcess;

    public event EventHandler<IObjectProgress.ProgressBarEventArgs> ProgressEvent;

    public event EventHandler CuttingEvent;


    private void MySecondInteract() 
    {
        if (IsKitchenObject() && _interact && AlreadyInputObject(GetKitchenObject().GetKitchenObjects()))
        {
            _cuttingProcess++;

            CuttingEvent?.Invoke(this, EventArgs.Empty);

            var cuttingObject = GetCuttingInputObjects(GetKitchenObject().GetKitchenObjects());

            ProgressEvent?.Invoke(this, new IObjectProgress.ProgressBarEventArgs
            {
                normalized = (float)_cuttingProcess / cuttingObject._cuttingTimes
            });

            if (_cuttingProcess >= cuttingObject._cuttingTimes)
            {
                var outputObject = GetInputObject(GetKitchenObject().GetKitchenObjects());

                GetKitchenObject().RemoveObject();
                KitchenObject.SpawnKitchenObject(outputObject, this);
                _interact = false;
            }
        }
    }

    public override void Interact(PlayerMovement playerMovement)
    {
        if (_interact) 
        {
            MySecondInteract();
            return;
        }
        if (!IsKitchenObject())
        {
            if (playerMovement.IsKitchenObject())
            {
                if (AlreadyInputObject(playerMovement.GetKitchenObject().GetKitchenObjects())) 
                {

                    playerMovement.GetKitchenObject().SetObjectProperties(this);
                    _interact = true;
                    _cuttingProcess = 0;

                    var cuttingObject = GetCuttingInputObjects(GetKitchenObject().GetKitchenObjects());
                    ProgressEvent?.Invoke(this, new IObjectProgress.ProgressBarEventArgs
                    {
                        normalized = (float)_cuttingProcess / cuttingObject._cuttingTimes
                    });
                }
            }
            else
            {

            }
        }
        else
        {
            if (playerMovement.IsKitchenObject())
            {
                if (playerMovement.GetKitchenObject().TryGetPlate(out PlateObject plateObject))
                {
                    if (plateObject.TryAddProduct(GetKitchenObject().GetKitchenObjects()))
                    {
                        GetKitchenObject().RemoveObject();
                    }
                }
            }
            else
            {
                GetKitchenObject().SetObjectProperties(playerMovement);
            }
        }
    }

    


    private bool AlreadyInputObject(KitchenObjects inputObject) 
    {
        var cuttingObjects = GetCuttingInputObjects(inputObject);

        return cuttingObjects != null;
    }

    private KitchenObjects GetInputObject(KitchenObjects inputObject)
    {
        var cuttingObjects = GetCuttingInputObjects(inputObject);

        if (cuttingObjects != null)
        {
            return cuttingObjects._outputObject;
        }
        else 
        {
            return null;
        }
    }

    private CuttingObjects GetCuttingInputObjects(KitchenObjects kitchenInputObjects)
    {
        foreach (var cuttingObject in _cuttingObjects)
        {
            if (cuttingObject._inputObject == kitchenInputObjects)
            {
                return cuttingObject;
            }
        }
        return null;
    }
}
