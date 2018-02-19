using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {


    public enum Type { Player, Enemy1,Enemy2, Enemy3 };



    public Type UserType;
    public int Initialhealth = 5;
    private int health;
    public bool dead = false;
    public bool haveDrop = false;
    public GameObject dropPrefav;
    public AudioClip explosion;
    public AudioClip takeDamage;

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

        if (this.tag == "Player")
        {
            Transform reference = FindObjectOfType<Canvas>().transform.Find("HPCount");

            reference.GetComponent<Text>().text = "x" + health;
        
            AudioSource.PlayClipAtPoint(takeDamage,new Vector3( 0, 0, 0));
            
        }

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

        AudioSource.PlayClipAtPoint(explosion, new Vector3(0, 0, 0));
        if (haveDrop)
        {
            DropPowerUp();
        }
        ScoreTracker reference = FindObjectOfType<Canvas>().GetComponentInChildren<ScoreTracker>();
        switch (UserType)
        {
            case Type.Enemy1:
                reference.AddScore(100);
                break;
            case Type.Enemy2:
                reference.AddScore(25);
                break;
            case Type.Enemy3:
                reference.AddScore(500);
                break;
            case Type.Player:
                FindObjectOfType<Canvas>().transform.Find("EndGame").gameObject.SetActive(true);
                break;                
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
