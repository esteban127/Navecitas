using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int Initialhealth = 5;
    private int health;
    public bool dead = false;
    public bool haveDrop = false;
    public GameObject dropPrefav;

    private List<GameObject> drops = new List<GameObject>();



    public static GameObject dropPoolContainer;
    public static GameObject DropPoolContainer
    {
        get { intializeDropPoolContainer(); return dropPoolContainer; }
        set { intializeDropPoolContainer(); dropPoolContainer = value; }
    }
    public static void intializeDropPoolContainer()
    {
        if (dropPoolContainer == null)
        {
            dropPoolContainer = new GameObject();
            dropPoolContainer.name = "Drop Pool Container";
        }
    }

    private void Start()
    {
        this.health = this.Initialhealth;

    }
    public void TakeDamage(int dmg)
    {

        this.health = this.health - dmg;

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
        if (haveDrop)
        {
            DropPowerUp();
        }
        this.gameObject.SetActive(false);
        this.dead = true;
       
    }

    private void DropPowerUp()
    {

        GameObject powerUp;
        if (this.drops.Count < 5)
        {

            powerUp = (GameObject)Instantiate(dropPrefav);
            drops.Add(powerUp);
            powerUp.transform.SetParent(DropPoolContainer.transform);

        }
        else
        {
            powerUp = drops.Find(x => !x.activeInHierarchy);
        }

        powerUp.SetActive(true);
        powerUp.transform.position = this.transform.position;


    }
}
