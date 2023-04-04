using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CuttingObjects : ScriptableObject
{
    public KitchenObjects _inputObject;
    public KitchenObjects _outputObject;
    public int _cuttingTimes;
}
