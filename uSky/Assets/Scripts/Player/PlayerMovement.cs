using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour
{
    private float rotateSpeed = 10;
    static float walkSpeed = 10;

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        MovePlayer();
    }

    void MovePlayer()
    {
        CharacterController controller = GetComponent<CharacterController>();
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = walkSpeed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }

}