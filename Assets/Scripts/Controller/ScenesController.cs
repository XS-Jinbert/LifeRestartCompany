public class ScenesController : Controller
{
    public ScenesController(){
        EventCenter<SceneEvent>.AddListener<string>(SceneEvent.Logo, LoadScenes);
        EventCenter<SceneEvent>.AddListener<string>(SceneEvent.Main, LoadScenes);
        EventCenter<SceneEvent>.AddListener<string>(SceneEvent.LifePrepare, LoadScenes);
        EventCenter<SceneEvent>.AddListener<string>(SceneEvent.LifeRestart, LoadScenes);
        EventCenter<SceneEvent>.AddListener<string>(SceneEvent.Achievement, LoadScenes);
        EventCenter<SceneEvent>.AddListener<string>(SceneEvent.MyLife, LoadScenes);
        EventCenter<SceneEvent>.AddListener<string>(SceneEvent.Test, LoadScenes);
    }

    /// <summary>
    /// 根据场景名切换场景
    /// </summary>
    /// <param name="sceneName">场景名</param>
    public void LoadScenes(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// 根据场景编号切换场景
    /// </summary>
    /// <param name="sceneName">场景ID</param>
    public void LoadScenes(int sceneID)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneID);
    }

    ~ScenesController()
    {
        EventCenter<SceneEvent>.RemoveListener<string>(SceneEvent.Logo, LoadScenes);
        EventCenter<SceneEvent>.RemoveListener<string>(SceneEvent.Main, LoadScenes);
        EventCenter<SceneEvent>.RemoveListener<string>(SceneEvent.LifePrepare, LoadScenes);
        EventCenter<SceneEvent>.RemoveListener<string>(SceneEvent.LifeRestart, LoadScenes);
        EventCenter<SceneEvent>.RemoveListener<string>(SceneEvent.Achievement, LoadScenes);
        EventCenter<SceneEvent>.RemoveListener<string>(SceneEvent.MyLife, LoadScenes);
        EventCenter<SceneEvent>.RemoveListener<string>(SceneEvent.Test, LoadScenes);
    }
}
