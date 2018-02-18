using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleColision : MonoBehaviour {
        
    public enum Type { Player, Enemy}

    public Type SelectType;
    public float invTime = 1.5f;

    private float currentInv = 0.0f;
	
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (currentInv<= 0)
        {
            //Stop playing inv animation

        
            switch (SelectType)
            {
                case Type.Player:


                    switch (collider.tag)
                    {
                        case "Enemy":                           
                            
                            this.GetComponent<HealthManager>().TakeDamage(1);
                            collider.GetComponent<HealthManager>().TakeDamage(1);
                            currentInv = invTime;                          

                            break;

                        case "PowerUp":

                            this.gameObject.GetComponent<Shot>().AddSpecial();

                            collider.gameObject.SetActive(false);

                            break;

                        case "EnemyBullet":

                            this.GetComponent<HealthManager>().TakeDamage(1);
                            currentInv = invTime;
                            collider.gameObject.SetActive(false);

                            break;

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
        else
        {
            //Play inv animation
            currentInv = currentInv - Time.deltaTime * 20;
        }
    }
}
