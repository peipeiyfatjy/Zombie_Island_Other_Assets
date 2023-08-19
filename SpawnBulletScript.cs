using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletScript : MonoBehaviour
{
    public AudioSource gunshot;
    public GameObject bullet;
    public float bulletOffset;
    // Start is called before the first frame update
    
    public void spawnBullet(float bulletX, float bulletY, float bulletZ, float bulletAngle)
    {
        gunshot.Play();
        if (bulletAngle == 0)
        {
            Instantiate(bullet, new Vector3(bulletX + bulletOffset, bulletY, bulletZ), Quaternion.Euler(Vector3.forward * bulletAngle));
        }
        else if (bulletAngle == 90)
        {
            Instantiate(bullet, new Vector3(bulletX, bulletY + bulletOffset, bulletZ), Quaternion.Euler(Vector3.forward * bulletAngle));
        }
        else if (bulletAngle == 180)
        {
            Instantiate(bullet, new Vector3(bulletX - bulletOffset, bulletY, bulletZ), Quaternion.Euler(Vector3.forward * bulletAngle));
        }
        else if (bulletAngle == 270)
        {
            Instantiate(bullet, new Vector3(bulletX, bulletY - bulletOffset, bulletZ), Quaternion.Euler(Vector3.forward * bulletAngle));
        }
    }
}
