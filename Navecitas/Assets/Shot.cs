using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public enum Type { Player , Enemy1 , Enemy3};

    public GameObject playerRef;
    public int bulletSpeed = 20;
    public GameObject bulletPrefab;
    public int poolSize = 10;
    public Type shooterType; 
    public float rate;
    private Vector3 direction;
    private float lastShot = 0.0f;
    private List<GameObject> projectiles = new List<GameObject>();

    public static GameObject projectilePoolContainer;
    public static GameObject ProjectilePoolContainer
    {
        get { intializeProjectilePoolContainer(); return projectilePoolContainer; }
        set { intializeProjectilePoolContainer(); projectilePoolContainer = value; }
    }

    public static void intializeProjectilePoolContainer()
    {
        if (projectilePoolContainer == null)
        {
            projectilePoolContainer = new GameObject();
            projectilePoolContainer.name = "Projectile Pool Container";
        }
    }


    void Update () {
        
        if(shooterType == Type.Enemy1 || shooterType == Type.Enemy3 || Input.GetAxisRaw("Jump") == 1)
        {
            if (this.lastShot < this.rate)
            {
                this.lastShot += Time.deltaTime;

            }
            else
            {
                
                Fire();
                this.lastShot = 0.0f;
            }

        }        

    }

    private void Fire()
    {
        switch (shooterType){
            case Type.Player:

                GameObject playerProjectile;
                if (this.projectiles.Count < this.poolSize)
                {

                    playerProjectile = (GameObject)Instantiate(bulletPrefab);
                    projectiles.Add(playerProjectile);
                    playerProjectile.transform.SetParent(ProjectilePoolContainer.transform);

                }
                else
                {
                    playerProjectile = projectiles.Find(x => !x.activeInHierarchy);
                }


                playerProjectile.SetActive(true);

                // Adjust for character height
                
                playerProjectile.transform.position = transform.position - new Vector3(0, -1, 0);
                playerProjectile.GetComponent<Projectile>().targetTag = "Enemy";
                playerProjectile.GetComponent<Projectile>().bulletSpeed = this.bulletSpeed;
                direction = new Vector3(0, 1, 0);
                playerProjectile.GetComponent<Projectile>().direction = this.direction;
                          


            break;

            case Type.Enemy1:

                GameObject enemy1Projectile;
                if (this.projectiles.Count < this.poolSize)
                {

                    enemy1Projectile = (GameObject)Instantiate(bulletPrefab);
                    projectiles.Add(enemy1Projectile);
                    enemy1Projectile.transform.SetParent(ProjectilePoolContainer.transform);

                }
                else
                {
                    enemy1Projectile = projectiles.Find(x => !x.activeInHierarchy);
                }


                enemy1Projectile.SetActive(true);

                // Adjust for character height
                enemy1Projectile.transform.position = transform.position - new Vector3(0, 0.5f, 0);
                enemy1Projectile.GetComponent<Projectile>().targetTag = "Player";
                enemy1Projectile.GetComponent<Projectile>().bulletSpeed = this.bulletSpeed;
                direction = new Vector3(0, -1, 0);
                enemy1Projectile.GetComponent<Projectile>().direction = this.direction;



            break;

            case Type.Enemy3:
                

                GameObject enemy3Projectile;
                if (this.projectiles.Count < this.poolSize)
                {

                    enemy3Projectile = (GameObject)Instantiate(bulletPrefab);
                    projectiles.Add(enemy3Projectile);
                    enemy3Projectile.transform.SetParent(ProjectilePoolContainer.transform);

                }
                else
                {
                    enemy3Projectile = projectiles.Find(x => !x.activeInHierarchy);
                }


                enemy3Projectile.SetActive(true);

                // Adjust for character height
                enemy3Projectile.transform.position = transform.position - new Vector3(0, 0.7f, 0);
                enemy3Projectile.GetComponent<Projectile>().targetTag = "Player";
                enemy3Projectile.GetComponent<Projectile>().bulletSpeed = this.bulletSpeed;
                Vector3 aim = playerRef.transform.position - this.transform.position;
                if (Mathf.Abs(aim.x) < Mathf.Abs(aim.y) )
                {
                    direction = aim / Mathf.Abs(aim.y);
                }
                else
                {
                    direction = aim / Mathf.Abs(aim.x);
                }
                enemy3Projectile.GetComponent<Projectile>().direction = this.direction;



                break;
        }
        
    }
}
