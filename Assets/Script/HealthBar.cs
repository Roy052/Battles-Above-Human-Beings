using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject unit;
    public bool attatched = false;
    bool isthisEnemy = false;
    public EnemyUnit eu;
    public Unit u;
    bool onetime = true;
    void Start()
    {

    }

    void Update()
    {
        if (attatched)
        {
            if (unit == null) Destroy(this.gameObject);
            if(unit.tag == "Unit" && onetime)
            {
                isthisEnemy = false;
                u = unit.GetComponent<Unit>();
                onetime = false;
            }
            else if(onetime)
            {
                isthisEnemy = true;
                eu = unit.GetComponent<EnemyUnit>();
                onetime = false;
            }

            if(isthisEnemy == true)
            {
                this.transform.localScale = new Vector2(0.6f * (eu.health / eu.maxhealth), this.transform.localScale.y);
            }
            else
            {
                this.transform.localScale = new Vector2(0.6f * (u.health / u.maxhealth), this.transform.localScale.y);
            }

            this.transform.position = unit.transform.position + new Vector3(0, -2f, 0);
        }
    }
}
