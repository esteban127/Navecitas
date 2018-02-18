using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour {

	public Vector3 direction { get; set;}
    public int bulletSpeed { get; set; }
   

    void Update () {
		transform.position += direction * Time.deltaTime * bulletSpeed;	
	}

	


		

}