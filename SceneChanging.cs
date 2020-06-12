using UnityEngine;

public class SceneChanging : MonoBehaviour
{
    
    public void Reload()
    {
        A_SCUtil.ReloadScene();
        StaticVals.isPaused = false;
    }

    public void Change(int index)
    {
        A_SCUtil.ChangeScene(index);
        StaticVals.isPaused = false;
    }

    public void Exit()
    {
        A_.Leave();
    }
    
}
