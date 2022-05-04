using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Character character;
    public int DelayAmount = 1;
    public float timer, upgradeTimer;
    public float health;
    int upgradeDelay = 90;
    public Sprite[] spritearray;
    SpriteRenderer spriteRenderer;
    public Character[] characterList;
    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        character = characterList[gm.characterNum];
        
        timer = 0;
        upgradeTimer = 0;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(wait());
        if (this.tag == "Town")
        {
            Debug.Log(this.name + " : " + character.name);
            character.heartIncrease += 1;
            character.mentalIncrease += 1;
        }
        else if (this.tag == "SmallCity")
        {
            character.heartIncrease += 2;
            character.mentalIncrease += 2;
            health += 40;
        }
        else if (this.tag == "BigCity")
        {
            character.heartIncrease += 3;
            character.mentalIncrease += 3;
            health += 80;
        }

    }

    private void OnDestroy()
    {
        if (this.tag == "Town")
        {
            character.heartIncrease -= 1;
            character.mentalIncrease -= 1;
        }
        else if (this.tag == "SmallCity")
        {
            character.heartIncrease -= 2;
            character.mentalIncrease -= 2;
        }
        else if (this.tag == "BigCity")
        {
            character.heartIncrease -= 3;
            character.mentalIncrease -= 3;
        }
        character.BuildingDestroyed(this.name[8] - '0');
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        upgradeTimer += Time.deltaTime;

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }


        if (upgradeTimer >= upgradeDelay)
        {
            Debug.Log("happen");
            upgradeTimer = 0f;
            if (this.tag == "Town")
            {
                this.tag = "SmallCity";
                spriteRenderer.sprite = spritearray[1];
                character.heartIncrease += 1;
                character.mentalIncrease += 1;
                health += 40;
            }
            else if (this.tag == "SmallCity")
            {
                this.tag = "BigCity";
                spriteRenderer.sprite = spritearray[2];
                character.heartIncrease += 1;
                character.mentalIncrease += 1;
                health += 40;
            }
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForEndOfFrame();
    }
}
