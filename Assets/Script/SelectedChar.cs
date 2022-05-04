using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedChar : MonoBehaviour
{
    // Start is called before the first frame update
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
