using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TabGameManager : MonoBehaviour
{
    #region SingletoneUI
    public static TabGameManager instance = null;
    public static TabGameManager GetInstance()
    {
        if (instance == null) // instance가 처음엔 null이고 다음 리턴에는 만들어져서 재실행되지 않는다.
        {
            GameObject go = new GameObject("@TabGameManager"); // @ObjectManager라는 오브젝트를 만들어주겠다.
            instance = go.AddComponent<TabGameManager>(); // ObjectManager라는 스크립트를 그 오브젝트에 AddComponent(추가)해주겠다.

            DontDestroyOnLoad(go); // 씬이 전환이 되더라도 파괴되지 않도록 하겠다.
        }
        return instance;
    }
    #endregion

    public string playerName = "Hit";
    public int level = 99;
    public int gold = 1000; // 추가, 삭제
    public int totalHP = 100; // 증가
    public int curHP = 100; // 감소, 증가

    

    public void AddGold(int gold)
    { 
        this.gold += gold;
    }
    public bool SpendGold(int gold)
    {
        if (this.gold >= gold)
        { 
           this.gold -= gold;  
 // this 는 gold라는 지역변수와 public으로 만들어준 gold라는 변수가 이름이 같기 때문에 구분해주기 위해 붙여줌.
            return true;
        }

        return false;
    }

    public void IncreaseTotalHP(int addHP)
    {
        totalHP += addHP;
    }

    public void SetCurrentHP(int HP)
    {
        curHP += HP;

        if (curHP > totalHP)
            curHP = totalHP; // 최대체력을 넘어가면 최대체력으로 값을 고정시켜버리고

        if (curHP < 0)
            curHP = 0; // 체력이 0이하가 되면 0으로 값을 고정시킨다.

 // Mathf.Clamp(curHP, 0, 100); 0보다 작으면 0으로 고정, 100보다 높으면 100으로 고정한다는 뜻. 위의 if함수 4줄을 한줄로 축약. 
    }

  
}
