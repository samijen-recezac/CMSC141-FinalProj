using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform PlayerRing;
    public Transform EnemyRing;

    Unit playerUnit;
    Unit enemyUnit;

    public TMP_Text dialogueText;
    public TMP_Text enemyText;

    public BattleHud playerHUD;
    public BattleHud enemyHUD;



    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, PlayerRing);
        playerUnit = playerGO.GetComponent<Unit>();
        
        GameObject enemyGo = Instantiate(enemyPrefab, EnemyRing);
        enemyUnit = enemyGo.GetComponent<Unit>();

        dialogueText.text = "You prepare for combat.";
        enemyText.text = "A " + enemyUnit.unitName + " appears.";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

        void PlayerTurn()
        {
            dialogueText.text = "Your turn. Choose an action: ";
        }
    }
}
