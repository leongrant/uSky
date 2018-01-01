using UnityEngine;
using UnityEngine.Networking;

public class LookAtMouse : NetworkBehaviour
{
    public float speed;

    void Update()
    {
        if(isLocalPlayer)
        {
            RotatePlayer();
        }  
    }
    void RotatePlayer()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
    }
}