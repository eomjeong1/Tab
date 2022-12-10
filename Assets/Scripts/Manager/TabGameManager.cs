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
        if (instance == null) // instance�� ó���� null�̰� ���� ���Ͽ��� ��������� �������� �ʴ´�.
        {
            GameObject go = new GameObject("@TabGameManager"); // @ObjectManager��� ������Ʈ�� ������ְڴ�.
            instance = go.AddComponent<TabGameManager>(); // ObjectManager��� ��ũ��Ʈ�� �� ������Ʈ�� AddComponent(�߰�)���ְڴ�.

            DontDestroyOnLoad(go); // ���� ��ȯ�� �Ǵ��� �ı����� �ʵ��� �ϰڴ�.
        }
        return instance;
    }
    #endregion

    public string playerName = "Hit";
    public int level = 99;
    public int gold = 1000; // �߰�, ����
    public int totalHP = 100; // ����
    public int curHP = 100; // ����, ����

    

    public void AddGold(int gold)
    { 
        this.gold += gold;
    }
    public bool SpendGold(int gold)
    {
        if (this.gold >= gold)
        { 
           this.gold -= gold;  
 // this �� gold��� ���������� public���� ������� gold��� ������ �̸��� ���� ������ �������ֱ� ���� �ٿ���.
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
            curHP = totalHP; // �ִ�ü���� �Ѿ�� �ִ�ü������ ���� �������ѹ�����

        if (curHP < 0)
            curHP = 0; // ü���� 0���ϰ� �Ǹ� 0���� ���� ������Ų��.

 // Mathf.Clamp(curHP, 0, 100); 0���� ������ 0���� ����, 100���� ������ 100���� �����Ѵٴ� ��. ���� if�Լ� 4���� ���ٷ� ���. 
    }

  
}
