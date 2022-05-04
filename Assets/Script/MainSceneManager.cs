using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public Text heartText, mentalText, heartIncreaseText, mentalIncreaseText, healthText, enemyHealthText;
    public Text systemMessage;
    public Character[] characterList;
    GameManager gm;
    public Character selectedChar;
    
    // Start is called before the first frame update
    private void Start()
    {
        systemMessage.text = "";
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        selectedChar = characterList[gm.characterNum];
        selectedChar.gameObject.SetActive(true);
    }

    public void CurrentStatus(float heartCount, float mentalCount, float heartIncrease, float mentalIncrease)
    {
        heartText.text = string.Format("{0:N1}", heartCount)  + "";
        mentalText.text = string.Format("{0:N1}", mentalCount) + "";
        heartIncreaseText.text = "+" + string.Format("{0:N1}", heartIncrease);
        mentalIncreaseText.text = "+" + string.Format("{0:N1}", mentalIncrease);
    }

    public void CurrentHealth(float health, float enemyHealth)
    {
        healthText.text = health + "";
        enemyHealthText.text = enemyHealth + "";
    }

    public void NotEnoughHeart()
    {
        systemMessage.GetComponent<SystemMessage>().notenoughHeart();
    }

    public void NotEnoughMental()
    {
        systemMessage.GetComponent<SystemMessage>().notenoughMental();
    }
    
}
