using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

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
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.UpdateHP(enemyUnit.currentHP, enemyUnit.maxHP);
        dialogueText.text = "The attack hits the dummy.";
        enemyText.text = "Dummy receives 2 damage.";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(2);
        playerHUD.UpdateHP(playerUnit.currentHP, playerUnit.maxHP);
        dialogueText.text = "You call help from nature. You recover 2HP.";
        enemyText.text = ". . .";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());

    }

    IEnumerator EnemyTurn()
    {
        enemyText.text = enemyUnit.unitName + " shakes.";
        dialogueText.text = enemyUnit.unitName + " softly hits you. You lose 1HP.";
        
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.UpdateHP(playerUnit.currentHP, playerUnit.maxHP);

        yield return new WaitForSeconds(1f);

        if (enemyUnit.currentHP<=0)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if(state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
            enemyText.text = "Dummy falls over.";
        }
        else if(state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
            enemyText.text = "Dummy says nothing.";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Your turn. Choose an action! ";
        enemyText.text = ". . .";
    }

    public void onAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void onHealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }
}
