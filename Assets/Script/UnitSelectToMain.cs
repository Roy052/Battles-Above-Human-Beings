using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectToMain : MonoBehaviour
{
    public UnitSelectSceneManager ussm;

    private void OnMouseDown()
    {
        ussm.UnitSelectToMain();
    }
}
