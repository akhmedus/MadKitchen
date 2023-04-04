using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BurnedObjects : ScriptableObject
{
    public KitchenObjects _inputObject;
    public KitchenObjects _outputObject;
    public int _burnedTimes;
}
