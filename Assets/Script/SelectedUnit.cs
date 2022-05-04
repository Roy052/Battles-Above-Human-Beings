using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUnit : MonoBehaviour
{    
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void selected()
    {
        this.gameObject.SetActive(true);
    }

    public void unselected()
    {
        this.gameObject.SetActive(false);
    }
}