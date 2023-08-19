using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveScript : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D bulletBody;
    public float bulletSpeed;
    string movingDirection;
    bool alreadyMoving;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        alreadyMoving = false;
    }
    private void Update()
    {
        if (!alreadyMoving)
        {
            if (player.transform.rotation.eulerAngles.z == 0)
            {
                movingDirection = "up";
                alreadyMoving = true;
            }
            else if (player.transform.rotation.eulerAngles.z == 90)
            {
                movingDirection = "left";
                alreadyMoving = true;
            }
            else if (player.transform.rotation.eulerAngles.z == 180)
            {
                movingDirection = "down";
                alreadyMoving = true;
            }
            else if (player.transform.rotation.eulerAngles.z == 270)
            {
                movingDirection = "right";
                alreadyMoving = true;
            }
        }
        moveBullet();
    }

    void moveBullet()
    {
        if (movingDirection == "up")
        {
            bulletBody.velocity = Vector2.up * bulletSpeed;
        }
        else if (movingDirection == "left")
        {
            bulletBody.velocity = Vector2.left * bulletSpeed;
        }
        else if (movingDirection == "down")
        {
            bulletBody.velocity = Vector2.down * bulletSpeed;
        }
        else if (movingDirection == "right")
        {
            bulletBody.velocity = Vector2.right * bulletSpeed;
        }

        if (transform.position.y > 40 || transform.position.y < -40 || transform.position.x > 50 || transform.position.x < -50)
        {
            Destroy(gameObject);
        }
    }
}
       
