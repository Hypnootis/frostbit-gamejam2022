using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingPatterns : MonoBehaviour
{
    private float elapsedTime = 0f;
    public GameObject player;
    // Start is called before the first frame update
    public GameObject bullet;
    private float bulletSpeed = 2.5f;
    private string[] patterns = {"straightShots", "playerShots"};
    GameObject newBullet;
    public SpriteRenderer spriteRenderer;
    private float animationTimer = 0f;
    public GameObject logic;
    private int attackCounter = 0;
    private int waveCounter = 0;
    ArrayList currentSprites = new ArrayList();
    private int ratCounter = 0;
    
    void Start()
    {
        player.GetComponent<Shoot>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        elapsedTime += Time.deltaTime;
        animationTimer += Time.deltaTime;
        if (elapsedTime >= 3.5f)
        {
            string pattern = patterns[Random.Range(0, 1)];
            if (pattern == "straightShots")
            {
                shootForward();
            }
            else if (pattern == "playerShots")
            {
                shootTowardsPlayer();
            }
            elapsedTime = 0f;
            attackCounter++;

        }

            if (animationTimer >= 3.5f)
            {
                if (logic.GetComponent<Waves>().waveRules() == "early")
                {

                    logic.GetComponent<Waves>().changeSprite(spriteRenderer, 1);
                    animationTimer = 0f;
                    if (animationTimer >= 1f)
                    {
                        logic.GetComponent<Waves>().changeSprite(spriteRenderer, 0);
                    }

                }
                if (logic.GetComponent<Waves>().waveRules() == "mid")
                {
                    logic.GetComponent<Waves>().changeSprite(spriteRenderer, 3);
                    animationTimer = 0f;
                    if (animationTimer >= 2f)
                    {
                        logic.GetComponent<Waves>().changeSprite(spriteRenderer, 2);
                        animationTimer = 0f;
                    }

                }
                animationTimer = 0f;

                if(logic.GetComponent<Waves>().waveRules() == "late")
                {
                logic.GetComponent<Waves>().changeSprite(spriteRenderer,  7 - ratCounter);
                if (ratCounter < 3)
                {
                    ratCounter++;
                }
                animationTimer = 0f;
                }
            animationTimer = 0f;
        }
        

            if (attackCounter >= 2)
            {
                waveCounter++;
                logic.GetComponent<Waves>().changeWave(waveCounter);
                attackCounter = 0;
            }



        }

    void shoot(Vector3 direction, GameObject projectile){
        Shoot.shoot(direction, 0f, projectile, this.gameObject, bulletSpeed);
    }
    void shootForward(){
        newBullet = Instantiate(this.bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Projectile>().shotType = "straightShots";
    }

    void shootTowardsPlayer(){
        newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Projectile>().shotType = "playerShots";
    }

    public void changeWeapon(GameObject newWeapon)
    {
        this.bullet = newWeapon;
    }

}
