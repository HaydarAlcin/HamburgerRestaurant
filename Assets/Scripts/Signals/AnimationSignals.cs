using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationSignals : MonoBehaviour 
{
    #region Singleton
    public static AnimationSignals Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
    }
    #endregion

    public UnityAction onTakeItemAnimationEvent = delegate { };
}
