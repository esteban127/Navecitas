using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BackgroundController : MonoBehaviour{

    public float scrolllSpeed;
	
	
	void Update () {
        transform.position += new Vector3(0,-1,0) * Time.deltaTime *scrolllSpeed; 
        
        if(transform.position.y < -19)
        {
            transform.position = new Vector3(0, 19, 0);
        }
	}
}
