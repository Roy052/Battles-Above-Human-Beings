using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectButton : MonoBehaviour
{
    public CharacterSelectSceneManager cssm;

    private void OnMouseDown()
    {
        if (this.gameObject.name == "croco")
        {
           
            cssm.selectCharacter(0);
        }
       else if(this.gameObject.name == "plant")
        {
            cssm.selectCharacter(1);

        }
        else if (this.gameObject.name == "spear")
        {
            cssm.selectCharacter(2);
        }
        else if (this.gameObject.name == "ys")
        {
            cssm.selectCharacter(3);
        }
    }
}
