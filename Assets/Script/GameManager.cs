using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float health, enemyHealth;
    public int characterNum;
    Character character;
    Enemycharacter enemycharacter;
    public GameObject[] characterList;
    int[] selectedUnit;
    public GameObject[] unitList;
    MainSceneManager msm;
    public Sprite[] btnImages;


    bool onetime = true;

    //삭제 예정
    public float unitsummonTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        selectedUnit = new int[3];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("CharacterNum : " + characterNum + ", selectedUnit : " 
            + selectedUnit[0] + ", " + selectedUnit[1] + ", " + selectedUnit[2]);
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Main")
        {
            //SetUp Unit
            if (onetime)
            {
                MainSetUp();
                onetime = false;
            }
        }
    }



    public void CurrentStatus(float heartCount, float mentalCount, float heartIncrease, float mentalIncrease)
    {
        msm.CurrentStatus(heartCount, mentalCount, heartIncrease, mentalIncrease);
        msm.CurrentHealth(health, enemyHealth);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void GameClear()
    {
        SceneManager.LoadScene("GameClear");
    }

    public void MenuToSelect()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void UnitSelection(int[] list)
    {
        for (int i = 0; i < 3; i++)
        {
            selectedUnit[i] = list[i];
        }
    }
    void MainSetUp()
    {
        msm = GameObject.Find("MainSceneManager").GetComponent<MainSceneManager>();
        character = msm.selectedChar;
        character.gameObject.SetActive(true);
        enemycharacter = GameObject.FindGameObjectWithTag("EnemyCharacter").GetComponent<Enemycharacter>();

        GameObject[] temp = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            temp[i] = unitList[selectedUnit[i]];
        }

        character.UnitSetUp(temp);

        for(int i = 0; i < 3; i++)
        {
            temp[i] = unitList[Random.Range(i*3, i*3 + 2)];
        }
        enemycharacter.UnitSetUp(temp);

        GameObject[] btnobject = GameObject.FindGameObjectsWithTag("Summon");
        Button[] btn = new Button[3];

        for(int i = 0; i < 3; i++)
        {
            btn[i] = btnobject[i].GetComponent<Button>();
            btn[i].image.sprite = btnImages[selectedUnit[i]];
        }
    }
}


