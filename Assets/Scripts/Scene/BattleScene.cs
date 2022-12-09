using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = ObjectManager.GetInstance().CreateMonster(); // 몬스터 생성함수를 오브젝트매니저에서 갖고 와서 변수로 선언해줄거야
        go.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f); // 스케일을 2.5만큼씩 키우기
        go.transform.localPosition = new Vector3(0, 0.6f, 0); // 포지션을 y축으로 0.6f 만큼 이동시킴.

        TabUI.GetInstance().SetEventSystem(); 
        TabUI.GetInstance().OpenUI("UIProfile");

        TabBattleManager.GetInstance().BattleStart(new Monster1());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
