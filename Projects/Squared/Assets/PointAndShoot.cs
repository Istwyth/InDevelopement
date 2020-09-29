using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject player; //weapon
    public GameObject bulletPrefab; // projectile
    public float bulletSpeed = 60.0f;
    private Vector3 target;
    public Transform firePosition;
    public Transform realPlayerThisTime;

    private PlayerMovement playerMovement = null;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        playerMovement = realPlayerThisTime.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if(playerMovement != null)
        {
            if((rotationZ <= 90 && rotationZ >= -90) && !playerMovement.facingRight)
            {
                playerMovement.FlipCharacter();
                //Debug.Log("Turn Right");
            } else
            {
                if ((rotationZ > 90 || rotationZ < -90) && playerMovement.facingRight)
                {
                    playerMovement.FlipCharacter();
                    //Debug.Log("Turn Left");
                }
                //Debug.Log("Else");
            }
            //Debug.Log("Not Null");
        }

        if(Input.GetMouseButtonDown(0))
        {
            //fire bullet
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
        }

        

    }
    void fireBullet(Vector2 direction, float rotationZ)
        {
            GameObject b = Instantiate(bulletPrefab) as GameObject;
        /*Transform firePosition = null;
        foreach(Transform child in player.transform)
        {
            if(child.name == "FirePosition")
            {
                firePosition = child;
            }
        }
        if (firePosition == null)
        {
            return;
        }*/
        b.transform.position = firePosition.transform.position;// + (Vector3.up * 2);//firePosition.localPosition; //
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        }
}
