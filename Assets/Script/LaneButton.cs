using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneButton : MonoBehaviour
{
    public int unitNum;
    public Character character;
    public MainSceneManager msm;
    public GameObject[] laneButtons;
    public int lane;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        msm = GameObject.Find("MainSceneManager").GetComponent<MainSceneManager>();
        character = msm.selectedChar;
        
    }


    private void OnMouseDown()
    {
        for(int i = 0; i < laneButtons.Length; i++)
        {
            laneButtons[i].SetActive(false);
        }
        character.UnitSummon(unitNum, lane);
    }
}
