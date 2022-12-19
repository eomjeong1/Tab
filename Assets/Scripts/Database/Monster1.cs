using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// class - ����Ÿ��
// struct - �� Ÿ��
public struct Monster1
{
    public string monsterName;
    public int atk;
    public int hp;
    public float delay; // ���Ͱ� ������ ���� �ӵ�
    public int gold;

    public Monster1(string monsterName, int atk, int hp, float delay, int gold)
    {
        this.monsterName = monsterName;
        this.atk = atk;
        this.hp = hp;
        this.delay = delay;
        this.gold = gold;
    }
}
