using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region SingletoneUI
    public static SoundManager instance = null;
    public static SoundManager GetInstance()
    {
        if (instance == null) // instance�� ó���� null�̰� ���� ���Ͽ��� ��������� �������� �ʴ´�.
        {
            GameObject go = new GameObject("@SoundManager"); // @ObjectManager��� ������Ʈ�� ������ְڴ�.
            instance = go.AddComponent<SoundManager>(); // ObjectManager��� ��ũ��Ʈ�� �� ������Ʈ�� AddComponent(�߰�)���ְڴ�.

            DontDestroyOnLoad(go); // ���� ��ȯ�� �Ǵ��� �ı����� �ʵ��� �ϰڴ�.
        }
        return instance;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
