using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _cuttingObject;
    [SerializeField]
    private Image _image;

    private IObjectProgress _cuttingProgress;
    private void Start()
    {
        _cuttingProgress = _cuttingObject.GetComponent<IObjectProgress>();
        _cuttingProgress.ProgressEvent += _cuttingProgress_ProgressEvent;
        _image.fillAmount = 0;

        Hide();
    }

    private void _cuttingProgress_ProgressEvent(object sender, IObjectProgress.ProgressBarEventArgs e)
    {
        _image.fillAmount = e.normalized;

        if (e.normalized == 0 || e.normalized == 1f)
        {
            Hide();
        }
        else 
        {
            Show();
        }
    }


    private void Show() 
    {
        gameObject.SetActive(true);
    }

    private void Hide() 
    {
        gameObject.SetActive(false);
    }
}
