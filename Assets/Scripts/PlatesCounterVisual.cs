using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField]
    private PlatesCounter _platesCounter;
    [SerializeField]
    private Transform _spawn;
    [SerializeField]
    private Transform _prefab;

    private List<GameObject> _platesStack;

    private void Awake()
    {
        _platesStack = new List<GameObject>();
    }

    private void Start()
    {
        _platesCounter.PlateSpawned += _platesCounter_PlateSpawned;
        _platesCounter.PlateRemoved += _platesCounter_PlateRemoved;
    }

    private void _platesCounter_PlateRemoved(object sender, System.EventArgs e)
    {
        var plate = _platesStack[_platesStack.Count - 1];
        _platesStack.Remove(plate);

        Destroy(plate);
    }

    private void _platesCounter_PlateSpawned(object sender, System.EventArgs e)
    {
        var platesCounter = Instantiate(_prefab, _spawn);

        var plateSet = .1f;
        platesCounter.localPosition = new Vector3(0, plateSet * _platesStack.Count, 0);

        _platesStack.Add(platesCounter.gameObject);
    }
}
