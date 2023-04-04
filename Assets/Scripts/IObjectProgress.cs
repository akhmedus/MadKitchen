using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectProgress
{
    public event EventHandler<ProgressBarEventArgs> ProgressEvent;

    public class ProgressBarEventArgs : EventArgs
    {
        public float normalized;
    }
}
