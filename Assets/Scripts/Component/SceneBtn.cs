using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBtn : MonoBehaviour
{
    public void ToScene(string sceneName)
    {
        DebugLog.Log("【SceneBtn跳转】跳转至SceneName");
        EventCenter<SceneEvent>.Broadcast(SceneEvent.ToScene, sceneName);
    }
}
