using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public float speed;
    public float rotateSpeed;

    public override void OnStartLocalPlayer()
    {
        if (isLocalPlayer)
        {
            Camera.main.GetComponent<CameraFollowPlayer>().setTarget(gameObject.transform);
        }

    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }

    }

    [Command]
    void CmdFire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 45;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 6.0f);
    }

    
}
