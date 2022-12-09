using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene
{
        Menu,
        Main,
        Battle 
}
public class SCenesManager : MonoBehaviour
{
    #region SingletoneUI
    public static SCenesManager instance = null;
    public static SCenesManager GetInstance()
    {
        if (instance == null) // instance가 처음엔 null이고 다음 리턴에는 만들어져서 재실행되지 않는다.
        {
            GameObject go = new GameObject("@ScenesManager"); // @UIManager라는 오브젝트를 만들어주겠다.
            instance = go.AddComponent<SCenesManager>(); // TabUI라는 스크립트를 그 오브젝트에 AddComponent(추가)해주겠다.

            DontDestroyOnLoad(go); // 씬이 전환이 되더라도 파괴되지 않도록 하겠다.
        }
        return instance; // 다시 인스턴스를 확인하러 가겠다. 안되어 있으면 만드는 것.
    }
    #endregion

    #region Scene Control
    public Scene currentScene;
    public Scene PrevScene;
    public void ChangeScene(Scene scene)
    {
        TabUI.GetInstance().ClearList(); // 씬이 바뀔때마다 UI매니저를 클리어해주겠다.
       // PrevScene = currentScene;
        currentScene = scene;
        SceneManager.LoadScene(scene.ToString());

    }
    #endregion
}

