using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public float heartCount = 0, mentalCount = 0, heartIncrease = 0, mentalIncrease = 0;
    public float health;
    public GameObject healthBar;
    GameObject[] units;
    GameObject[] laneButtons;
    GameManager gm;
    public float[,] lanes;
    MainSceneManager msm;
    int DelayAmount = 1;
    float timer;

    // 0 : Ability, 1 : heart cost, 2 : mental cost
    int[,] unitInfo;
    //0 : damage, 1 : delay, 2 : health, 3 : speed
    float[,] unitInfo1;

    // Start is called before the first frame update
    void Start()
    {
        //Lane Information
        laneButtons = GameObject.FindGameObjectsWithTag("Lane");
        lanes = new float[3, 2];
        lanes[0, 0] = -13.5f; lanes[0, 1] = -3.35f;
        lanes[1, 0] = -13.5f; lanes[1, 1] = 0;
        lanes[2, 0] = -13.5f; lanes[2, 1] = 3.35f;

        unitInfo = new int[3, 2];
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        msm = GameObject.Find("MainSceneManager").GetComponent<MainSceneManager>();

        units = new GameObject[3];
        this.gameObject.SetActive(false);
        if(this.name == "char1")
        {
            GameObject[] buildings = GameObject.FindGameObjectsWithTag("Town");
            if(buildings != null)
            for(int i = 0; i < buildings.Length; i++)
            {
                buildings[i].GetComponent<Building>().upgradeTimer -= 10;
            }
        }
        
        if (this.name == "char2")
        {
            heartIncrease += 2;
        }
        else if (this.name == "char4")
        {
            mentalIncrease += 2;
        }

        
    }

    void FixedUpdate()
    {
        Debug.Log(this.name);
        gm.CurrentStatus(heartCount, mentalCount, heartIncrease, mentalIncrease);
        gm.health = health;

        if (health <= 0)
        {
            gm.GameOver();
        }
        timer += Time.deltaTime;

        heartCount += heartIncrease * Time.deltaTime;
        mentalCount += mentalIncrease * Time.deltaTime;
    }

    public void UnitSummon(int unitnum, int lane)
    {
        Debug.Log("Enter");
        if (heartCount < unitInfo[unitnum, 0])
        {
            msm.NotEnoughHeart();
        }
        else if (mentalCount < unitInfo[unitnum, 1])
        {
            msm.NotEnoughMental();
        }
        else
        {
            // »ý¼º
            GameObject clone = Instantiate(units[unitnum], 
                new Vector3(lanes[lane, 0], lanes[lane, 1], 0), Quaternion.identity);
            heartCount -= unitInfo[unitnum, 0];
            mentalCount -= unitInfo[unitnum, 1];
            GameObject healthBarClone = Instantiate(healthBar,
                new Vector3(lanes[lane, 0], lanes[lane, 1], 0), Quaternion.identity);
            healthBarClone.GetComponent<HealthBar>().unit = clone;
            healthBarClone.GetComponent<HealthBar>().attatched = true;
            if (this.name == "char3")
            {
                clone.GetComponent<Unit>().damage += 0.2f;
                clone.GetComponent<Unit>().delay -= 0.05f;
            }
        }
    }

    //Accept Unit Info from GameManager
    public void UnitSetUp(GameObject[] list)
    { 
        for (int i = 0; i < 3; i++)
        {
            units[i] = list[i];
            unitInfo[i, 0] = units[i].GetComponent<Unit>().heartCost;
            unitInfo[i, 1] = units[i].GetComponent<Unit>().mentalCost;
        }
    }

    public void BuildingDestroyed(int num)
    {
        laneButtons[num].transform.position += new Vector3(-6, 0, 0);
        lanes[num, 0] = -20f;
    }
}

