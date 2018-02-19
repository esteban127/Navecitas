using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleColision : MonoBehaviour {
        
    public enum Type { Player, Enemy}

    public Type SelectType;
    public float invTime = 1.5f;
    public AudioClip pickUp;
    int fade = 4;
    private float currentInv = 0.0f;


    private void Update()
    {
        
        if (this.tag == "Player")
        {
            if (currentInv <= 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else
            {
                fade++;
                currentInv -= Time.deltaTime;
                if ( fade > 4)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                }
                if (fade > 8){
                    this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                    fade = 0;
                }
            }
        }       
            
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        
         

        
        switch (SelectType)
        {
            case Type.Player:

                if (collider.tag == "PowerUp")
                {
                    this.gameObject.GetComponent<Shot>().AddSpecial();

                    AudioSource.PlayClipAtPoint(pickUp, new Vector3(0, 0, 0));

                    collider.gameObject.SetActive(false);
                }

                if (currentInv <= 0)
                {
                    
                    switch (collider.tag)
                    {
                        case "Enemy":                           
                            
                            this.GetComponent<HealthManager>().TakeDamage(1);
                            collider.GetComponent<HealthManager>().TakeDamage(1);
                            currentInv = invTime;                          

                            break;                       

                        case "EnemyBullet":

                            this.GetComponent<HealthManager>().TakeDamage(1);
                            currentInv = invTime;
                            collider.gameObject.SetActive(false);

                            break;

                    }
                }               

                break;

            case Type.Enemy:

                if(collider.tag == "PlayerBullet")
                {
                    this.GetComponent<HealthManager>().TakeDamage(1);
                    currentInv = invTime;
                    collider.gameObject.SetActive(false);
                }
                break;
        }
    }
}
