using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour {

    public string targetTag { get; set; }
    public float duration { get; set; }
    public int damage { get; set; }

    // Update is called once per frame
    void Update () {
		this.duration = this.duration - Time.deltaTime;
        if (this.duration <= 0)
        {

            this.gameObject.SetActive(false);

        }
        

	}

    void OnTriggerEnter2D(Collider2D collider)
    {


        if (collider.tag == targetTag)
        {
                    
            HealthManager healthManager = collider.GetComponentInParent<HealthManager>();
            if (healthManager != null)
            {

                healthManager.TakeDamage(this.damage);

            }
            else
            {
                Debug.LogError("Projectile collided with object that doesn't have a Health Manager");
            }
        }

        if (collider.tag == "EnemyBullet")
        {
            collider.gameObject.SetActive(false);
        }




    }
}
