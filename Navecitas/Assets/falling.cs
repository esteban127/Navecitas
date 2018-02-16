using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling : MonoBehaviour {

    public float fallingSpeed = 5.0f;
	
	void Update () {

        this.transform.position += new Vector3(0, -1, 0) * fallingSpeed * Time.deltaTime;
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Wall")
        {
            this.gameObject.SetActive(false);
        }
    }
}
