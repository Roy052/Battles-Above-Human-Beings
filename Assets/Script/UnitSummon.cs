using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSummon : MonoBehaviour
{
    public int unitNum;
    public GameManager gm;
    public Button thisbutton;
    public GameObject[] laneButtons;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickButton()
    {
        for(int i = 0; i < laneButtons.Length; i++)
        {
            laneButtons[i].SetActive(true);
            laneButtons[i].GetComponent<LaneButton>().unitNum = unitNum;
        }
        thisbutton.interactable = false;
        StartCoroutine(buttonActive());
    }

    public IEnumerator buttonActive()
    {
        yield return new WaitForSeconds(gm.unitsummonTime);
        thisbutton.interactable = true;
    }
}
