using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : MonoBehaviour
{
    private void Start()
    {
        ControllerManager.Use();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DebugLog.Log("Try to go to Main Scene");
            EventCenter<SceneEvent>.Broadcast(SceneEvent.Main, "Main");
        }
    }
}
