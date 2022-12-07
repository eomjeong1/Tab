using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    Button btnStart;
    // Start is called before the first frame update
    void Start()
    {
        btnStart = GetComponentInChildren<Button>(); // Button�̶�� ����ƼUI��� ��ũ��Ʈ���� �����´ٴ� ��.
        btnStart.onClick.AddListener(OnClickStart); // ��Ŭ����ư�� �������� OnClickStart �Լ��� Ȱ��ȭ
    }

    // Update is called once per frame
    void OnClickStart()
    {
        SCenesManager.GetInstance().ChangeScene(Scene.Main); // ���⼭ Scene�� �Ʊ� enum���� �������� ��.
    }
}
