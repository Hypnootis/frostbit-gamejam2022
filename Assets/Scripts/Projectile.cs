using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

public float speed = 4f;
    Rigidbody2D rb;

    GameObject target;
    Vector2 moveDirection;
    public string shotType;
    // Start is called before the first frame update

    public Projectile(string shotType){
        this.shotType = shotType;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (shotType == "playerShots"){
            towardsPlayer();
        }
        else if (shotType == "straightShots"){
            rb.velocity = new Vector2(0f, 3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onBecameInvisible(){
        Destroy(gameObject);
    }

    GameObject getTarget(){
        return GameObject.FindWithTag("Player");
    }

    void towardsPlayer(){
        target = getTarget();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }
}
