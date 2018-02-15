using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour {

	public Vector3 direction { get; set;}
	public string targetTag { get; set; }
    public int bulletSpeed { get; set; }
   

    void Update () {
		transform.position += direction * Time.deltaTime * bulletSpeed;	
	}

	void OnTriggerEnter2D(Collider2D collider) {
    
           
        if (collider.tag == targetTag)
        {
            gameObject.SetActive(false);
            this.direction = Vector3.zero;
            HealthManager healthManager = collider.GetComponentInParent<HealthManager>();            
            if(healthManager != null)
            {
                healthManager.TakeDamage();
            } else
            {
                Debug.LogError("Projectile collided with object that doesn't have a Health Manager");
            }
        }        

        if (collider.tag == "Wall")
        {
            gameObject.SetActive(false);
            this.direction = Vector3.zero;                
        }        
	}


		

}