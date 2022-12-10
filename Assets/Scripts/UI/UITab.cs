using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITab : MonoBehaviour
{
    Button btnTab;
    public AudioSource audioSource;
    private void Start()
    {
        btnTab = GetComponentInChildren<Button>();
        btnTab.onClick.AddListener(OnTab);
        audioSource = GetComponent<AudioSource>();

    }
    void OnTab()
    {
        TabBattleManager.GetInstance().AttackMonster();
        Object characterObj = Resources.Load("Effect/Hit2");
        Debug.Log("АјАн!");
        audioSource.Play();
    }
}
