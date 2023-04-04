using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardAnimator : MonoBehaviour
{
    [SerializeField]
    private CuttingBoard _cuttingBoard;
    [SerializeField]
    private Animator _animator;

    private void Start()
    {
        _cuttingBoard.CuttingEvent += _cuttingBoard_CuttingEvent;
    }

    private void _cuttingBoard_CuttingEvent(object sender, System.EventArgs e)
    {
        _animator.SetTrigger("Cut");
    }

}
