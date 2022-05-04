using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharToSelectUnit : MonoBehaviour
{
    public CharacterSelectSceneManager cssm;
    private void OnMouseDown()
    {
        cssm.SelectCharToSelectUnit();
    }
}
