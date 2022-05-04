using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // Start is called before the first frame update
    public float  damage, delay, health, speed;
    public int ability, heartCost, mentalCost;
    Rigidbody2D rb2d;
    
    Vector2 movement;
    float timer;
    bool needForce;
    LayerMask mask;

    void Start()
    {
        movement = new Vector2(1, 0);
        mask = LayerMask.GetMask("Enemy", "Ally");
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }

        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, mask);
        if (hit.collider != null)
        {
            Debug.Log("Ray" + hit.transform.name);
            // Calculate the distance from the surface and the "error" relative
            // to the floating height.
            float distance = Mathf.Abs(hit.point.x - transform.position.x);
            if(distance > 2)
            {
               rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
            }
            else
            {
                if (timer >= delay)
                {
                    timer = 0f;
                    if (hit.transform.tag == "EnemyUnit")
                    {
                        hit.transform.GetComponent<EnemyUnit>().health -= damage;
                    }
                    else if (hit.transform.tag == "EnemyCharacter")
                    {
                        hit.transform.GetComponent<Enemycharacter>().health -= damage;
                    }
                    else if (hit.transform.tag == "EnemyTown" || hit.transform.tag == "EnemySmallCity" || hit.transform.tag == "EnemyBigCity")
                    {
                        hit.transform.GetComponent<Building>().health -= damage;
                    }
                }

            }
        }
        else
        {
            rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
        }
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }

    private void OnDestroy()
    {
        
    }

}
