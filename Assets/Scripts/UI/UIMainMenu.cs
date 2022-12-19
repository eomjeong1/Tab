using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    Button[] btnStart;
    // Start is called before the first frame update
    void Start()
    {
        btnStart = GetComponentsInChildren<Button>(); // Button�̶�� ����ƼUI��� ��ũ��Ʈ���� �����´ٴ� ��.
        btnStart[0].onClick.AddListener(OnClickStart);
        btnStart[1].onClick.AddListener(OnClickStart2);// ��Ŭ����ư�� �������� OnClickStart �Լ��� Ȱ��ȭ
    }

    // Update is called once per frame
    void OnClickStart()
    {
        TabGameManager.GetInstance().characterIdx = 0;
        SCenesManager.GetInstance().ChangeScene(Scene.Main); // ���⼭ Scene�� �Ʊ� enum���� �������� ��.
    }
    void OnClickStart2()
    {
        TabGameManager.GetInstance().characterIdx = 1;
        SCenesManager.GetInstance().ChangeScene(Scene.Main); // ���⼭ Scene�� �Ʊ� enum���� �������� ��.
    }
}

