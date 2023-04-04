using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterWork : MonoBehaviour
{
    [SerializeField]
    private StoveCounter _stoveCounter;
    [SerializeField]
    private GameObject _stove;
    [SerializeField]
    private GameObject _particle;

    private void Start()
    {
        _stoveCounter.StateChanged += _stoveCounter_StateChanged;
    }

    private void _stoveCounter_StateChanged(object sender, StoveCounter.StateChangedEventArgs e)
    {
        var show = e.cutletState == StoveCounter.CutletState.Frying
            || e.cutletState == StoveCounter.CutletState.Fried;

        _stove.SetActive(show);
        _particle.SetActive(show);
    }
}
