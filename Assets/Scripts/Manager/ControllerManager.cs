using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager
{
    static ScenesController scenesController = new ScenesController();

    // 加载场景前调用，在Awake执行之后
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Main() {
        DebugLog.Log("【游戏初始化】ControllerManager初始化成功");
    }
}
