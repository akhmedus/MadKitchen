using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class KitchenObjects : ScriptableObject
{
    public Transform _prefab;
    public Sprite _sprite;
    [SerializeField]
    private string _name;
}
