using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    public AudioSource MDie;
    public Animation Die;
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        // monster.gameObject.SetActive(true);
        GameObject go = ObjectManager.GetInstance().CreateMonster(); // ���� �����Լ��� ������Ʈ�Ŵ������� ���� �ͼ� ������ �������ٰž�
        go.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f); // �������� 2.5��ŭ�� Ű���
        go.transform.localPosition = new Vector3(0, -2, 0); // �������� y������ 0.6f ��ŭ �̵���Ŵ.
        
        TabUI.GetInstance().SetEventSystem(); 
        TabUI.GetInstance().OpenUI("UIProfile");

        TabBattleManager.GetInstance().BattleStart(new Monster1());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MonsterDie()
    {
        MDie.Play();
       // GameObject go = ObjectManager.GetInstance().CreateMDie(); // ���� �����Լ��� ������Ʈ�Ŵ������� ���� �ͼ� ������ �������ٰž�
       // go.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f); // �������� 2.5��ŭ�� Ű���
       // go.transform.localPosition = new Vector3(0, -2, 0);


    }
}
