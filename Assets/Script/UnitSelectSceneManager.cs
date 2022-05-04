using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnitSelectSceneManager : MonoBehaviour
{
    public int[] selectedUnitNum;
    GameManager gm;
    int selectedCount = 0;
    
    public Text duplicatemessage;
    float[,] location;

    public GameObject[] unitMain0;
    public GameObject[] unitMain1;
    public GameObject[] unitMain2;


    // Start is called before the first frame update
    void Start()
    {
        selectedUnitNum = new int[3];
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        selectedUnitNum[0] = 0;
        selectedUnitNum[1] = 3;
        selectedUnitNum[2] = 6;
        duplicatemessage.text = "";


        unitMain0[0].GetComponent<SelectedUnit>().selected();
        unitMain1[3].GetComponent<SelectedUnit>().selected();
        unitMain2[6].GetComponent<SelectedUnit>().selected();
    }

    public void SelectUnit(int num)
    {
        if (selectedCount == 3) ResetUnit();
        for(int i = 0; i < selectedCount; i++)
        {
            if (selectedUnitNum[i] == num)
            {
                NoDuplicate();
                return;
            } 
        }
        switch (selectedCount)
        {
            case 0:
                unitMain0[selectedUnitNum[selectedCount]].GetComponent<SelectedUnit>().unselected();
                unitMain0[num].GetComponent<SelectedUnit>().selected();
                break;
            case 1:
                unitMain1[selectedUnitNum[selectedCount]].GetComponent<SelectedUnit>().unselected();
                unitMain1[num].GetComponent<SelectedUnit>().selected();
                break;
            case 2:
                unitMain2[selectedUnitNum[selectedCount]].GetComponent<SelectedUnit>().unselected();
                unitMain2[num].GetComponent<SelectedUnit>().selected();
                break;
        }
        selectedUnitNum[selectedCount] = num;
        selectedCount++;
    }

    public void ResetUnit()
    {
        selectedCount = 0;
    }

    public void NoDuplicate()
    {
        duplicatemessage.text = "The units are duplicated.";
        StartCoroutine(waitfordispear());
    }

    public IEnumerator waitfordispear()
    {
        yield return new WaitForSeconds(1.5f);
        duplicatemessage.text = "";
    }

    public void UnitSelectToMain()
    {
        gm.UnitSelection(selectedUnitNum);
        SceneManager.LoadScene("Main");
    }
}
