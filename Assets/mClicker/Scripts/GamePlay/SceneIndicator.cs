using System;
using UnityEngine;

public class SceneIndicator : MonoBehaviour
{
    public static event Action DisabledScene;

    public void OnDestroy()
    {
        DisabledScene?.Invoke();
    }
}
