using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconUI : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    public void SetIconSprite(KitchenObjects kitchenObjects) 
    {
        _image.sprite = kitchenObjects._sprite;
    }
}
