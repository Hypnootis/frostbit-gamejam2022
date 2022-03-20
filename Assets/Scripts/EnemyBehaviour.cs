using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    float cooldown = 2.5f;
    public float speed = 4.5f;
     Vector3 direction = Vector3.right;
    Dictionary<int, Vector3> directions = new Dictionary<int, Vector3>{{1, Vector3.right}, {2, Vector3.left}};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;


        if (transform.position.x <= -1.1){
            direction = Vector3.right;
        }
        else if (transform.position.x >= 1.1){
            direction = Vector3.left;
        }
        transform.Translate(direction * speed * Time.deltaTime);
        }
    }





