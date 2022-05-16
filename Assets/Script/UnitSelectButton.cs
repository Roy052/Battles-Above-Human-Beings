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

    private void OnMouseEnter()
    {
        ussm.unitInfo.GetComponent<UnitInfo>().unitnum = num;
        ussm.unitInfo.SetActive(true);
    }

    private void OnMouseExit()
    {
        ussm.unitInfo.SetActive(false);
    }
}
