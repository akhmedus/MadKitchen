using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IObjectProperties
{

    [SerializeField]
    private float _playerSpeed = 8f;
    private float _playerRotate = 9f;

    private bool _isMoving = false;

    [SerializeField]
    private InputManager _inputManager;

    private float _targetRadius = .7f;
    private float _targetHeight = 2f;

    private Vector2 _playerVector;
    private Vector3 _direction;
    private Vector3 _currentPosition;

    [SerializeField]
    private LayerMask _kitchenware;

    private MainCounter _selectedCounter;

    [HideInInspector]
    public event EventHandler<SelectedKitchenwareEvent> _selectedKitchenwareEvent;
    [HideInInspector]
    public class SelectedKitchenwareEvent : EventArgs 
    {
        public MainCounter selectedCounter;
    }

    public static PlayerMovement PMInstance { get; private set; }

    [SerializeField]
    private Transform _spawn;

    private KitchenObject _kitchenObject;

    private int counter = 0;

    private void Awake()
    {
        if (PMInstance != null) 
        {
            Debug.Log("Error");
        }
        PMInstance = this;

    }

    private void Start()
    {
        _inputManager._secondInteractActions += _inputManager__secondInteractActions;
        _inputManager._interactActions += _inputManager__interactActions;

    }

    private void _inputManager__secondInteractActions(object sender, EventArgs e)
    {
        if (_selectedCounter != null)
        {
            _selectedCounter.SecondInteract(this);
        }
    }

    private void _inputManager__interactActions(object sender, EventArgs e)
    {
        if (_selectedCounter != null) 
        {
            _selectedCounter.Interact(this);
        }
    }

    private void Update()
    {
        TragetMovement();
        ObjectInteraction();
    }


    private void TragetMovement()
    {
        _playerVector = _inputManager.PlayerVector();

        _direction = new Vector3(_playerVector.x, 0, _playerVector.y);


        float pathLength = _playerSpeed * Time.deltaTime;
        bool freezing = !Physics.CapsuleCast(transform.position, transform.position +
            Vector3.up * _targetHeight, _targetRadius, _direction, pathLength);

        if (!freezing)
        {
            var Xdirection = new Vector3(_direction.x, 0, 0);
            freezing = Xdirection.x != 0 && !Physics.CapsuleCast(transform.position, transform.position +
                Vector3.up * _targetHeight, _targetRadius, Xdirection, pathLength);

            if (freezing) 
            {
                _direction = Xdirection;
            }
            else
            {
                var Zdirection = new Vector3(_direction.z, 0, 0);
                freezing = Zdirection.z != 0 && !Physics.CapsuleCast(transform.position, transform.position +
                    Vector3.up * _targetHeight, _targetRadius, Zdirection, pathLength);

                if (freezing) 
                {
                    _direction = Zdirection;
                }
            }
        }

        if (freezing)
        {
            transform.position = transform.position + _direction * pathLength;
        }

        _isMoving = _direction != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, _direction, Time.deltaTime * _playerRotate);

    }

    public bool IsMoving() 
    {
        return _isMoving;
    }


    private void ObjectInteraction()
    {
        if (_direction != Vector3.zero) 
        {
            _currentPosition = _direction;
        }

        if (Physics.Raycast(transform.position, _currentPosition, out RaycastHit hit, 1.5f, _kitchenware))
        {
            if (hit.transform.TryGetComponent(out MainCounter mainCounter)) 
            {
                if (mainCounter != _selectedCounter)
                {
                    SetSelectedKitchenware(mainCounter);
                }
            }
            else
            {
                SetSelectedKitchenware(null);
            }
        }
        else
        {
            SetSelectedKitchenware(null);
        }
    }

    private void SetSelectedKitchenware(MainCounter mainCounter) 
    {
        this._selectedCounter = mainCounter;

        _selectedKitchenwareEvent?.Invoke(this, new SelectedKitchenwareEvent
        {
            selectedCounter = mainCounter
        });
    }

    public Transform GetNextCounterSpawn()
    {
        return _spawn;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this._kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return _kitchenObject;
    }

    public void CleanKitchenObject()
    {
        _kitchenObject = null;
    }

    public bool IsKitchenObject()
    {
        return _kitchenObject != null;
    }
}
