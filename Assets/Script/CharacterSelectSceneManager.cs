using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectSceneManager : MonoBehaviour
{
    public GameObject[] charactermain;
    public GameObject[] character;
    int selectedCharacterNum = 0;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        charactermain[0].GetComponent<SelectedChar>().selected();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectCharacter(int charnum)
    {
        charactermain[selectedCharacterNum].GetComponent<SelectedChar>().unselected();
        charactermain[charnum].GetComponent<SelectedChar>().selected();
        selectedCharacterNum = charnum;
    }

    public void SelectCharToSelectUnit()
    {
        Debug.Log("selectedCharacterNum : " + selectedCharacterNum);
        gm.characterNum = selectedCharacterNum;
        SceneManager.LoadScene("UnitSelect");
    }
}
