using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHud : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text levelText;
    public TMP_Text hpText;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "Lvl " + unit.unitLevel;
        hpText.text = "HP " + unit.currentHP + "/" + unit.maxHP;
    }

    public void UpdateHP(int currentHP, int maxHP)
    {
        if (currentHP < 0)
            currentHP = 0;

        hpText.text = "HP " + currentHP + "/" + maxHP;
    }

}
