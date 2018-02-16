using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleColision : MonoBehaviour {

	
        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("meleColision detected");

            if (collider.tag == "Enemy")
            {

                HealthManager healthManager = collider.GetComponentInParent<HealthManager>();
                Debug.Log("Got Health Manager" + healthManager.GetType().ToString());
                if (healthManager != null)
                {
                    this.GetComponent<HealthManager>().TakeDamage(1);
                    healthManager.TakeDamage(1);
                }
                else
                {
                    Debug.LogError("Projectile collided with object that doesn't have a Health Manager");
                }
            }

            if (collider.tag == "PowerUp")
            {

                this.gameObject.GetComponent<Shot>().AddSpecial();

                collider.gameObject.SetActive(false); 

            }

        }
}
