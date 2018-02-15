using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcaterController : MonoBehaviour {


    public float vel;

	void Update () {

        int directionH = (int)Input.GetAxisRaw("Horizontal");
        int directionV = (int)Input.GetAxisRaw("Vertical");


        if (directionH == 1 )
        {
            if (this.transform.position.x < 5)
                this.transform.position += new Vector3(0.05f, 0, 0)*Time.deltaTime * vel;
        }
        else if (directionH == -1)
        {
            if (this.transform.position.x > -5)
                this.transform.position += new Vector3(-0.05f, 0, 0) * Time.deltaTime * vel;
        }

        if (directionV == 1)
        {

            if (this.transform.position.y < 9.5)
                this.transform.position += new Vector3(0,  0.05f, 0) * Time.deltaTime * vel;
        }
        else if (directionV == -1)
        {
            if (this.transform.position.y > -9.5)
                this.transform.position += new Vector3(0,  -0.05f, 0) * Time.deltaTime * vel;
            
               
        }
               
    }


}
