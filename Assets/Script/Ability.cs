using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    bool isthisEnemy = false;
    EnemyUnit enemyUnit;
    Unit unit;
    int ability;
    Character character;

    private void Start()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        character = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();

        if (this.GetComponent<EnemyUnit>() == null)
        {
            isthisEnemy = false;
            unit = this.GetComponent<Unit>();
            ability = unit.ability;
        }
        else
        {
            isthisEnemy = true;
            enemyUnit = this.GetComponent<EnemyUnit>();
            ability = enemyUnit.ability;
        }

        Debug.Log("Abitiy : " + ability + ", " + character.name );
        switch (this.ability)
        {
            
            case 0:
                break;
            case 1:
                character.heartIncrease += 0.5f;
                break;
            case 2:
                character.mentalIncrease += 0.5f;
                break;
            case 3:
                break;
        }
    }

    private void OnDestroy()
    {
        switch (this.ability)
        {
            case 0:
                break;
            case 1:
                character.heartIncrease -= 0.5f;
                break;
            case 2:
                character.mentalIncrease -= 0.5f;
                break;
            case 3:
                break;
        }
    }
}
