using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// class - 참조타입
// struct - 값 타입
public struct Monster1
{
    public string monsterName;
    public int atk;
    public int hp;
    public float delay; // 몬스터가 때릴때 공격 속도
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
