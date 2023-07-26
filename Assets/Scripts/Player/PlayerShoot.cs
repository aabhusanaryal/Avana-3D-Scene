using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    float bulletSpeed = 10.0f;
    [SerializeField]
    Camera cam;
    [SerializeField]
    GameObject bulletOrigin;
    public static readonly Vector3 BulletRot = new Vector3(90.0f, 0, 0);
    [SerializeField]
    AudioSource gun;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot()
    {
        GameObject b = Instantiate(bullet, bulletOrigin.transform.position,cam.transform.rotation);
        gun.Play();
        b.transform.Rotate(BulletRot);
        b.GetComponent<Rigidbody>().velocity = cam.transform.forward * bulletSpeed;
    }
}
