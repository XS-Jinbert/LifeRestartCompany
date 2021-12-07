public class ScenesController : Controller
{
    public ScenesController(){
        EventCenter<SceneEvent>.AddListener<string>(SceneEvent.ToScene, LoadScenes);
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
        EventCenter<SceneEvent>.RemoveListener<string>(SceneEvent.ToScene, LoadScenes);
    }
}
