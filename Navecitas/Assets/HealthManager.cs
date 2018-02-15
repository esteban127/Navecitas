using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int Initialhealth = 5;
    private int health;
    public bool dead = false;

    private void Start()
    {
        this.health = this.Initialhealth;

    }
    public void TakeDamage()
    {

        this.health--;

        if (this.health <= 0)
        {
            this.Death();
        }

    }
    public void ResetHealt()
    {
        this.health = Initialhealth;
    }

    public void Death()
    {
        this.gameObject.SetActive(false);
        this.dead = true;
    }

}
