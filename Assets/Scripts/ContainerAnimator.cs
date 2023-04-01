using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerAnimator : MonoBehaviour
{
    [SerializeField]
    private ContainerCounter _containerCounter;
    [SerializeField]
    private Animator _animator;

    private void Start()
    {
        _containerCounter._playerInteraction += _containerCounter__playerInteraction;
    }

    private void _containerCounter__playerInteraction(object sender, System.EventArgs e)
    {
        _animator.SetTrigger("Interaction");
    }
}
