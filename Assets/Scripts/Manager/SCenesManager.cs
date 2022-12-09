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
        if (instance == null) // instance�� ó���� null�̰� ���� ���Ͽ��� ��������� �������� �ʴ´�.
        {
            GameObject go = new GameObject("@ScenesManager"); // @UIManager��� ������Ʈ�� ������ְڴ�.
            instance = go.AddComponent<SCenesManager>(); // TabUI��� ��ũ��Ʈ�� �� ������Ʈ�� AddComponent(�߰�)���ְڴ�.

            DontDestroyOnLoad(go); // ���� ��ȯ�� �Ǵ��� �ı����� �ʵ��� �ϰڴ�.
        }
        return instance; // �ٽ� �ν��Ͻ��� Ȯ���Ϸ� ���ڴ�. �ȵǾ� ������ ����� ��.
    }
    #endregion

    #region Scene Control
    public Scene currentScene;
    public Scene PrevScene;
    public void ChangeScene(Scene scene)
    {
        TabUI.GetInstance().ClearList(); // ���� �ٲ𶧸��� UI�Ŵ����� Ŭ�������ְڴ�.
       // PrevScene = currentScene;
        currentScene = scene;
        SceneManager.LoadScene(scene.ToString());

    }
    #endregion
}

