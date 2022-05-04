using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectButton : MonoBehaviour
{
    public UnitSelectSceneManager ussm;
    int num;
    private void Start()
    {
        num = this.gameObject.name[4] - '0';
    }
    private void OnMouseDown()
    {
        ussm.SelectUnit(num);
    }
}
