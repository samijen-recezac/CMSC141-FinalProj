using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform PlayerRing;
    public Transform EnemyRing;

    //Unit playerUnit;
    //Unit enemyUnit;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        //GameObject playerGO = 
        Instantiate(playerPrefab, PlayerRing);
        //playerGO.GetComponent<Unit>();
        
        //GameObject enemyGo = 
        Instantiate(enemyPrefab, EnemyRing);
        //enemyGo.GetComponent<Unit>();

        //enemyUnit.unitName
    }
}
