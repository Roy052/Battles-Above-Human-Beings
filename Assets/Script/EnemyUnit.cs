using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage, delay, health, speed, maxhealth;
    public int ability;
    public Rigidbody2D rb2d;
    Vector2 movement;
    float timer;
    bool needForce;
    LayerMask mask;

    void Start()
    {
        movement = new Vector2(-1, 0);
        mask = LayerMask.GetMask("Ally", "Enemy");
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        maxhealth = health;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity, mask);
        if (hit.collider != null)
        {
            Debug.Log("Ray" + hit.transform.name);
            // Calculate the distance from the surface and the "error" relative
            // to the floating height.
            float distance = Mathf.Abs(hit.point.x - transform.position.x);
            if (distance > 2)
            {
                rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
            }
            else
            {
                if (timer >= delay)
                {
                    timer = 0f;
                    if (hit.transform.tag == "Unit")
                    {
                        hit.transform.GetComponent<Unit>().health -= damage;
                    }
                    else if (hit.transform.tag == "Character")
                    {
                        hit.transform.GetComponent<Character>().health -= damage;
                    }
                    else if (hit.transform.tag == "Town" || hit.transform.tag == "SmallCity" || hit.transform.tag == "BigCity")
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

}

