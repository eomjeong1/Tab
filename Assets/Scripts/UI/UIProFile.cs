using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TMPro �� �־�� TMP�� ����ȴ�.

public class UIProFile : MonoBehaviour
{
    public Slider hpBar;
    public Image imgFill;

    public TMP_Text txtLevel;
    public TMP_Text txtName;
    public TMP_Text txtGold;
    public TMP_Text txtHP;

    // Start is called before the first frame update
    void Start()
    {
        RefreshState();
        HPBarChange();



    }

    // Update is called once per frame
    public void RefreshState()
    {

        txtLevel.text = $"LV. {TabGameManager.GetInstance().level}";
        txtName.text = $"{TabGameManager.GetInstance().playerName}";
        txtGold.text = $"{TabGameManager.GetInstance().gold}g";


        hpBar.maxValue = TabGameManager.GetInstance().totalHP;
        hpBar.value = TabGameManager.GetInstance().curHP;
        txtHP.text = $"{hpBar.value} / {hpBar.maxValue}";
    }
    public void HPBarChange()
    {
        if(TabGameManager.GetInstance().curHP < 40)
            imgFill.color = Color.red;
        else
            imgFill.color = Color.green;

    }
}
