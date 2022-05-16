using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfo : MonoBehaviour
{
    public int unitnum = 0;
    private Vector2 mousePosition;
    public GameObject unitImage;
    public Sprite[] unitImageList;
    SpriteRenderer unitImageRenderer;
    public GameObject[] prefabs;
    public Text ability;
    string[] abilityTexts =
    {
        "No Ability", "1 health per second", "1 mind per second", "something", 
        "something", "something", "something", "something", "something"
    };
    void Start()
    {
        unitImageRenderer = unitImage.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        unitImageRenderer.sprite = unitImageList[unitnum];
        ability.text = abilityTexts[unitnum];

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x + 1.3f, mousePosition.y - 2);
        unitImage.transform.position = new Vector2(mousePosition.x + 1.3f, mousePosition.y - 1);
        ability.transform.position = new Vector2(mousePosition.x + 1.2f, mousePosition.y - 2.6f);
    }
}
