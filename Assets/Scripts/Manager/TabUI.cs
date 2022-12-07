using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TabUI : MonoBehaviour
{
    #region SingletoneUI
    public static TabUI instance = null;
    public static TabUI GetInstance()
    {
        if (instance == null) // instance�� ó���� null�̰� ���� ���Ͽ��� ��������� �������� �ʴ´�.
        {
            GameObject go = new GameObject("@UIManager"); // @UIManager��� ������Ʈ�� ������ְڴ�.
            instance = go.AddComponent<TabUI>(); // TabUI��� ��ũ��Ʈ�� �� ������Ʈ�� AddComponent(�߰�)���ְڴ�.

            DontDestroyOnLoad(go); // ���� ��ȯ�� �Ǵ��� �ı����� �ʵ��� �ϰڴ�.
        }
        return instance;
    }
    #endregion

    #region UI Control

    public void SetEventSystem()
    {
        if (FindObjectOfType<EventSystem>() == false) // �̺�Ʈ�ý����� ������
        {
            GameObject go = new GameObject("@EventSystem"); // ���ӿ�����Ʈ�� �̸��� "@EventSystem"���� ������� ���̴�.
            go.AddComponent<EventSystem>(); // EventSystem�̶�� ����� �߰�
            go.AddComponent<StandaloneInputModule>(); // StandaloneInputModule�̶�� ����� �߰�
        }
    }

    // uipopup  gameObj
    // uiMenu   menuObj
    Dictionary<string, GameObject> uiList = new Dictionary<string, GameObject>();

    public void OpenUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == false) // uiList�� uiName�̶�� Ű�� �������� �ʴ´ٸ�(51�ٷ�)
        {

            // 1. ���ҽ��� �ε�
            Object uiObj = Resources.Load("UI/"+uiName); 
            // ���ҽ� ���� ���� �ִ� UI��� ���� ���� �� ������ �Ǿ��ֱ� ������ "UI/"�� ��θ� ǥ�����־���.

            // 2. ������ ����
            GameObject go = (GameObject)Instantiate(uiObj); // uiObj�� �Ʊ� ���ҽ� �ȿ��� �ҷ��� ������
            uiList.Add(uiName, go); // uiList �� string�� GameObject�� �̷���� Dictionary�̴�.
            // �� �ȿ��� �ҷ��� ������ ���ְڴٴ� ��.
        }
        else 
        {
            uiList[uiName].SetActive(true);
        }
    }


    public void CloseUI(string uiName)
    {
        if (uiList.ContainsKey(uiName) == true)
        {
            uiList[uiName].SetActive(false);
        }
    }
    #endregion  
}



