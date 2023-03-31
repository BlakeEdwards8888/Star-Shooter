using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetingStrategy : MonoBehaviour
{
    public abstract event Action onTargetAcquired;
    public abstract Transform GetTarget();
}
