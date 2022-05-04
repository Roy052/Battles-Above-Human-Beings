using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMessage : MonoBehaviour
{
    public Text thistext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void notenoughHeart()
    {
        Debug.Log("NotEnoughHeart");
        thistext.text = "Not Enough Heart";
        StartCoroutine(messageTime());
        
    }

    public void notenoughMental()
    {
        thistext.text = "Not Enough Mental";
        StartCoroutine(messageTime());
        
    }

    public IEnumerator messageTime()
    {
        yield return new WaitForSeconds(1.5f);
        thistext.text = "";
    }
}
