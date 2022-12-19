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

    public Player[] playerData = new Player[]
{
        new Player("Character", 10, 500, 100, 100),
        new Player("Character2", 50, 1000, 150, 120)
};
    public int characterIdx = 0; // 0 - warrior 1 - skull
    // ĳ���� 1
    public int warriorHp = 100;
    public string warriorImg = "Character";

    // ĳ���� 2
    public int skullHp = 120;
    public string skullImg = "Character2";

    public Player SetPlayer(int num)
    {
        return playerData[num];
    }


    public void LoadData()
    {
        playerName = PlayerPrefs.GetString("playerName", "Hitman");

        level = PlayerPrefs.GetInt("level", 1);
        gold = PlayerPrefs.GetInt("gold", 500);
        totalHP = PlayerPrefs.GetInt("totalHP", 100);
        curHP = PlayerPrefs.GetInt("curHp", 100);
    }

    public void SaveData()
    {
        PlayerPrefs.SetString("playerName", playerName);
        PlayerPrefs.SetInt("gold", gold);
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("totalHP", 100);
        PlayerPrefs.SetInt("curHP", 100);
    }

    public void AddGold(int gold)
    { 
        this.gold += gold;
        SaveData();
    }
    public bool SpendGold(int gold)
    {
        if (this.gold >= gold)
        { 
           this.gold -= gold;
            SaveData();
            // this �� gold��� ���������� public���� ������� gold��� ������ �̸��� ���� ������ �������ֱ� ���� �ٿ���.
            return true;
        }

        return false;
    }

    public void IncreaseTotalHP(int addHP)
    {
        totalHP += addHP;
        SaveData();
    }

    public void SetCurrentHP(int HP)
    {
        curHP += HP;

        if (curHP > totalHP)
            curHP = totalHP; // �ִ�ü���� �Ѿ�� �ִ�ü������ ���� �������ѹ�����

        if (curHP < 0)
            curHP = 0; // ü���� 0���ϰ� �Ǹ� 0���� ���� ������Ų��.

        SaveData();
        // Mathf.Clamp(curHP, 0, 100); 0���� ������ 0���� ����, 100���� ������ 100���� �����Ѵٴ� ��. ���� if�Լ� 4���� ���ٷ� ���. 
    }

  
}
