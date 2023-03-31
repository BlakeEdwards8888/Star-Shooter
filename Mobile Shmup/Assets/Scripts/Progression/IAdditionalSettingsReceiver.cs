using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAdditionalSettingsReceiver
{
    public void EvaluateSettings(List<string> settings);
}
