using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float bulletSpeed = 5f;
    private float fireRate = 0.5f;
    private float canFire = 0.0f;
    public GameObject projectile;
    public GameObject player;
    public GameObject crosshair;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        
        crosshair.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -4f);

        Vector3 difference = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float rotationZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        crosshair.transform.position = new Vector3(mousePosition.x, mousePosition.y, crosshair.transform.position.z);

        Quaternion rotation = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        canFire += Time.deltaTime;

        if (Input.GetMouseButtonDown(0)){
            if (canFire >= fireRate){
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();
                shoot(direction, rotationZ, projectile, player, bulletSpeed);
                canFire = 0f;
            }
        }
    }

    public static void shoot(Vector2 direction, float rotationZ, GameObject projectile, GameObject obj, float speed){
        if (projectile != null)
        {
            GameObject bullet = Instantiate(projectile);
            bullet.transform.position = obj.transform.position;
            bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    public void changeProjectile(GameObject newProjectile)
    {
        this.projectile = newProjectile;
    }
}
