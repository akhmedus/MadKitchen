using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.MPE;
using UnityEngine;
using static CuttingBoard;

public class StoveCounter : MainCounter, IObjectProgress
{
    [SerializeField]
    private FryingObjects[] _fryingObjects;
    [SerializeField]
    private BurnedObjects[] _burnedObjects;
 
    private bool _interact = false;

    [SerializeField]
    private float _timer;

    private FryingObjects _fryingObject;
    private BurnedObjects _burnedObject;
    public enum CutletState {
        Idle,
        Frying,
        Fried,
        Burned
    }
    private CutletState _cutletState;
    [SerializeField]
    private float _burningTime;


    public event EventHandler<IObjectProgress.ProgressBarEventArgs> ProgressEvent;

    public event EventHandler<StateChangedEventArgs> StateChanged;
    public class StateChangedEventArgs : EventArgs 
    {
        public CutletState cutletState;
    }

    private void Start()
    {
        _cutletState = CutletState.Idle;
    }
    private void Update()
    {
        if (IsKitchenObject())
        {
            switch (_cutletState)
            {
                case CutletState.Idle:
                    break;
                case CutletState.Frying:
                    FryingProcess();
                    break;
                case CutletState.Fried:
                    BurningProcess();
                    break;
                case CutletState.Burned:
                    break;
            }
        }
    }

    private void BurningProcess()
    {
        _burningTime += Time.deltaTime;

        ProgressEvent?.Invoke(this, new IObjectProgress.ProgressBarEventArgs
        {
            normalized = _burningTime / _burnedObject._burnedTimes
        });

        if (_burningTime > _burnedObject._burnedTimes)
        {
            GetKitchenObject().RemoveObject();

            KitchenObject.SpawnKitchenObject(_burnedObject._outputObject, this);

            _cutletState = CutletState.Burned;

            StateChanged?.Invoke(this, new StateChangedEventArgs
            {
                cutletState = _cutletState
            });

            ProgressEvent?.Invoke(this, new IObjectProgress.ProgressBarEventArgs
            {
                normalized = 0
            });
        }
    }

    private void FryingProcess()
    {
        _timer += Time.deltaTime;

        ProgressEvent?.Invoke(this, new IObjectProgress.ProgressBarEventArgs
        {
            normalized = _timer / _fryingObject._fryingTimes
        });

        if (_timer > _fryingObject._fryingTimes)
        {
            _timer = 0;

            GetKitchenObject().RemoveObject();

            KitchenObject.SpawnKitchenObject(_fryingObject._outputObject, this);

            _cutletState = CutletState.Fried;
            _burnedObject = GetBurningInputObjects(GetKitchenObject().GetKitchenObjects());

            StateChanged?.Invoke(this, new StateChangedEventArgs
            {
                cutletState = _cutletState
            });
        }
    }

    public override void Interact(PlayerMovement playerMovement)
    {
        if (!IsKitchenObject())
        {
            if (playerMovement.IsKitchenObject())
            {
                if (AlreadyInputObject(playerMovement.GetKitchenObject().GetKitchenObjects()))
                {
                    playerMovement.GetKitchenObject().SetObjectProperties(this);

                    _fryingObject = GetFryingInputObjects(GetKitchenObject().GetKitchenObjects());

                    _cutletState = CutletState.Frying;
                    _burningTime = 0;

                    StateChanged?.Invoke(this, new StateChangedEventArgs
                    {
                        cutletState = _cutletState
                    });


                    ProgressEvent?.Invoke(this, new IObjectProgress.ProgressBarEventArgs
                    {
                        normalized = _timer / _fryingObject._fryingTimes
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

                        _cutletState = CutletState.Idle;

                        StateChanged?.Invoke(this, new StateChangedEventArgs
                        {
                            cutletState = _cutletState
                        });

                        ProgressEvent?.Invoke(this, new IObjectProgress.ProgressBarEventArgs
                        {
                            normalized = 0
                        });
                    }
                }
            }
            else
            {
                GetKitchenObject().SetObjectProperties(playerMovement);

                _cutletState = CutletState.Idle;

                StateChanged?.Invoke(this, new StateChangedEventArgs
                {
                    cutletState = _cutletState
                });

                ProgressEvent?.Invoke(this, new IObjectProgress.ProgressBarEventArgs
                {
                    normalized = 0
                });
            }
        }
    }


    private bool AlreadyInputObject(KitchenObjects inputObject)
    {
        var fryingObject = GetFryingInputObjects(inputObject);

        return fryingObject != null;
    }

    private KitchenObjects GetInputObject(KitchenObjects inputObject)
    {
        var fryingObject = GetFryingInputObjects(inputObject);

        if (fryingObject != null)
        {
            return fryingObject._outputObject;
        }
        else
        {
            return null;
        }
    }

    private FryingObjects GetFryingInputObjects(KitchenObjects kitchenInputObjects)
    {
        foreach (var fryingObject in _fryingObjects)
        {
            if (fryingObject._inputObject == kitchenInputObjects)
            {
                return fryingObject;
            }
        }
        return null;
    }

    private BurnedObjects GetBurningInputObjects(KitchenObjects kitchenInputObjects)
    {
        foreach (var burningObject in _burnedObjects)
        {
            if (burningObject._inputObject == kitchenInputObjects)
            {
                return burningObject;
            }
        }
        return null;
    }
}
