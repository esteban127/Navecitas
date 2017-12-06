using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcaterController : MonoBehaviour {


    public float vel = 0;
    public GameObject playerBullet;

	void Update () {

        int directionH = (int)Input.GetAxisRaw("Horizontal");
        int directionV = (int)Input.GetAxisRaw("Vertical");


        if (directionH == 1 )
        {
            this.transform.position += new Vector3(vel * 0.05f, 0, 0);
        }
        else if (directionH == -1)
        {
            this.transform.position += new Vector3(vel * -0.05f, 0, 0);
        }

        if (directionV == 1)
        {
            this.transform.position += new Vector3(0, vel * 0.05f, 0);
        }
        else if (directionV == -1)
        {
            this.transform.position += new Vector3(0, vel * -0.05f, 0);
        }

        if (Input.GetAxisRaw("Jump") == 1)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        //refactorizar para usar pool
        playerBullet.transform.position = this.transform.position;
        playerBullet.SetActive(true);
    }
}
