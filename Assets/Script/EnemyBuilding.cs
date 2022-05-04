using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilding : MonoBehaviour
{
    Enemycharacter enemyCharacter;
    public int DelayAmount = 1;
    float timer, upgradeTimer;
    public float health;
    int upgradeDelay = 90;
    public Sprite[] spritearray;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        enemyCharacter = GameObject.FindGameObjectWithTag("EnemyCharacter").GetComponent<Enemycharacter>();

        timer = 0;
        upgradeTimer = 0;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        if (this.tag == "Town")
        {
            enemyCharacter.heartIncrease += 1;
            enemyCharacter.mentalIncrease += 1;
        }
        else if (this.tag == "SmallCity")
        {
            enemyCharacter.heartIncrease += 2;
            enemyCharacter.mentalIncrease += 2;
            health += 40;
            
        }
        else if (this.tag == "BigCity")
        {
            enemyCharacter.heartIncrease += 3;
            enemyCharacter.mentalIncrease += 3;
            health += 80;
        }
    }

    private void OnDestroy()
    {
        if (this.tag == "Town")
        {
            enemyCharacter.heartIncrease -= 1;
            enemyCharacter.mentalIncrease -= 1;
        }
        else if (this.tag == "SmallCity")
        {
            enemyCharacter.heartIncrease -= 2;
            enemyCharacter.mentalIncrease -= 2;
        }
        else if (this.tag == "BigCity")
        {
            enemyCharacter.heartIncrease -= 3;
            enemyCharacter.mentalIncrease -= 3;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        upgradeTimer += Time.deltaTime;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        if (timer >= DelayAmount)
        {
            timer = 0f;
            if (this.tag == "Town")
            {
                enemyCharacter.HeartCountIncrease(1);
                enemyCharacter.MentalCountIncrease(1);
            }
            else if (this.tag == "SmallCity")
            {
                enemyCharacter.HeartCountIncrease(2);
                enemyCharacter.MentalCountIncrease(2);
            }
            else if (this.tag == "BigCity")
            {
                enemyCharacter.HeartCountIncrease(3);
                enemyCharacter.MentalCountIncrease(3);
            }
        }

        if (upgradeTimer >= upgradeDelay)
        {
            upgradeTimer = 0f;
            if (this.tag == "Town")
            {
                this.tag = "SmallCity";
                spriteRenderer.sprite = spritearray[1];
                enemyCharacter.heartIncrease += 1;
                enemyCharacter.mentalIncrease += 1;
                health += 40;
            }
            else if (this.tag == "SmallCity")
            {
                this.tag = "BigCity";
                spriteRenderer.sprite = spritearray[2];
                enemyCharacter.heartIncrease += 1;
                enemyCharacter.mentalIncrease += 1;
                health += 40;
            }
        }
    }
}
