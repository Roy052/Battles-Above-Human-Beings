using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycharacter : MonoBehaviour
{
    public int heartCount, mentalCount, heartIncrease, mentalIncrease;
    public float health;
    public GameObject healthBar;
    public GameObject[] units;
    public GameObject[] laneButtons;
    public GameManager gm;
    public float[,] lanes;
    public int level;
    int type;
    GameObject[,] laneUnit;
    int[] laneNum;
    int[] count = new int[3];
    
    // 0 heart cost, 1 : mental cost
    int[,] unitInfo;

    //time
    float timer;
    float upgradeDelay = 90, upgradeDelay2;

    // Start is called before the first frame update
    void Start()
    {
        heartCount = 0;
        mentalCount = 0;
        heartIncrease = 0;
        mentalIncrease = 0;
        lanes = new float[3, 2];
        lanes[0, 0] = 13.5f; lanes[0, 1] = 3.35f;
        lanes[1, 0] = 13.5f; lanes[1, 1] = 0;
        lanes[2, 0] = 13.5f; lanes[2, 1] = -3.35f;

        type = Random.Range(0, 2);

        unitInfo = new int[3, 3];

        if (level == 0)
        {
            heartCount = 5;
            mentalCount = 5;
        }
        else if (level == 1)
        {
            heartCount = 10;
            mentalCount = 10;
        }
        else
        {
            heartCount = 20;
            mentalCount = 20;
        }

        units = new GameObject[3];
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        

        //Lane Info
        laneUnit = new GameObject[3, 30];
        laneNum = new int[3];
        for (int i = 0; i < 3; i++) laneNum[i] = 0;

        StartCoroutine(wait());
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            gm.GameClear();
        }
        gm.enemyHealth = health;

        timer += Time.deltaTime;
        
        if(timer < upgradeDelay)
        {
            if (heartCount >= unitInfo[0, 0] * 3 && mentalCount >= unitInfo[0, 1] * 3)
            {
                UnitSummon(0, 0);
                UnitSummon(0, 1);
                UnitSummon(0, 2);
            }
        }
        else if(timer < upgradeDelay2)
        {
            if (heartCount >= unitInfo[0, 0] * 3 && mentalCount >= unitInfo[0, 1] * 3)
            {
                UnitSummon(1, 0);
                UnitSummon(1, 1);
                UnitSummon(1, 2);
            }

        }
        else
        {
            if (heartCount >= unitInfo[0, 0] * 3 && mentalCount >= unitInfo[0, 1] * 3)
            {
                UnitSummon(2, 0);
                UnitSummon(2, 1);
                UnitSummon(2, 2);
            }

        }
    }

    public void UnitSummon(int unitnum, int lane)
    {
        Debug.Log("Enter");
        // »ý¼º
        GameObject clone = Instantiate(units[0], new Vector3(lanes[lane, 0], lanes[lane, 1], 0), Quaternion.identity);
        laneUnit[unitnum, laneNum[lane]] = clone;
        clone.AddComponent<EnemyUnit>();
        clone.GetComponent<EnemyUnit>().damage = clone.GetComponent<Unit>().damage;
        clone.GetComponent<EnemyUnit>().delay = clone.GetComponent<Unit>().delay;
        clone.GetComponent<EnemyUnit>().health = clone.GetComponent<Unit>().health;
        clone.GetComponent<EnemyUnit>().speed = clone.GetComponent<Unit>().speed;
        clone.GetComponent<EnemyUnit>().ability = clone.GetComponent<Unit>().ability;
        clone.transform.localScale = new Vector3(-1, 1, 1);
        Destroy(clone.GetComponent<Unit>());

        

        clone.tag = "EnemyUnit";
        clone.layer = LayerMask.NameToLayer("Enemy");
        if(level == 1)
        {
            clone.GetComponent<Unit>().damage *= 1.1f;
            clone.GetComponent<Unit>().delay *= 0.9f;
            clone.GetComponent<Unit>().health *= 1.1f;
        }
        if(level == 2)
        {
            clone.GetComponent<Unit>().damage *= 1.2f;
            clone.GetComponent<Unit>().delay *= 0.8f;
            clone.GetComponent<Unit>().health *= 1.2f;
        }

        //Cost
        heartCount -= unitInfo[unitnum, 0];
        mentalCount -= unitInfo[unitnum, 1];

        GameObject healthBarClone = Instantiate(healthBar,
                new Vector3(lanes[lane, 0], lanes[lane, 1], 0), Quaternion.identity);
        healthBarClone.GetComponent<HealthBar>().unit = clone;
        healthBarClone.GetComponent<HealthBar>().attatched = true;
    }

    public void HeartCountIncrease(int amount)
    {
        heartCount += amount;
    }
    public void MentalCountIncrease(int amount)
    {
        mentalCount += amount;
    }

    IEnumerator wait()
    {
        yield return new WaitForEndOfFrame();
    }

    public void UnitSetUp(GameObject[] list)
    {
        for (int i = 0; i < 3; i++)
        {
            units[i] = list[i];
            unitInfo[i, 0] = units[i].GetComponent<Unit>().heartCost;
            unitInfo[i, 1] = units[i].GetComponent<Unit>().mentalCost;
        }
    }

    public void FieldStatus()
    {
        bool unitExist = false;
        

        for(int i = 0; i < 3; i++)
        {
            count[i] = 0;
            for(int j = 0; j < laneNum[i]; i++)
            {
                if(laneUnit[i, j] != null)
                {
                    unitExist = true;
                    count[i]++;
                    break;
                }
            }

            if(unitExist == false)
            {
                laneNum[i] = 0;
            }
        }

    }
}
