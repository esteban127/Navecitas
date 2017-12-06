using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour {

	public float bulletSpeed;
	
	void Update () {

        this.transform.position += new Vector3(0, bulletSpeed * 0.05f, 0);

    }
}
