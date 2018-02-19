using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public enum Type { Enemy1, Enemy2, Enemy3 }

    public int velocity = 20;
    public Type enemyType;
    private int direction = 1;

	
	
	void Update () {
		switch (enemyType)
        {
            case Type.Enemy1:
                this.transform.position += new Vector3(0, -1, 0) * Time.deltaTime * velocity;
                break;
            case Type.Enemy2:
                this.transform.position += new Vector3(1 * direction, -0.8f, 0) * Time.deltaTime * velocity;
                if (this.transform.position.x <= -4.9){
                    direction = 1;
                }
                if (this.transform.position.x >= 4.9)
                {
                        direction = -1;
                }
                    
                break;
            case Type.Enemy3:
                this.transform.position += new Vector3(0, -0.25f, 0) * Time.deltaTime * velocity;
                break;
        }
        if (this.transform.position.y <= -10)
            this.gameObject.SetActive(false);
	}
}
