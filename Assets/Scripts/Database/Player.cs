using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Player 
{
    public string characterName;
    public int level;
    public int gold;
    public int totalHP;
    public int curHP;

    public Player(string characterName, int level, int gold, int totalHP, int curHP)
    { 
        this.characterName = characterName;
        this.level = level;
        this.gold = gold;
        this.totalHP = totalHP;
        this.curHP = curHP;
    }
}
