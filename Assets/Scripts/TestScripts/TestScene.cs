using UnityEngine;

public class TestScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DebugLog.Log("SceneEvent：Try to go to Main Scene");
            EventCenter<SceneEvent>.Broadcast(SceneEvent.Main, "Main");
        }
    }
}
