using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = ObjectManager.GetInstance().CreateMonster(); // ���� �����Լ��� ������Ʈ�Ŵ������� ���� �ͼ� ������ �������ٰž�
        go.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f); // �������� 2.5��ŭ�� Ű���
        go.transform.localPosition = new Vector3(0, 0.6f, 0); // �������� y������ 0.6f ��ŭ �̵���Ŵ.

        TabUI.GetInstance().SetEventSystem(); 
        TabUI.GetInstance().OpenUI("UIProfile");

        TabBattleManager.GetInstance().BattleStart(new Monster1());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
