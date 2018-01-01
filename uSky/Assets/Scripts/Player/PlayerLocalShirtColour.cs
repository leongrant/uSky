using UnityEngine.Networking;
using UnityEngine;

public class PlayerLocalShirtColour : NetworkBehaviour
{
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
        Debug.Log("hello");
    }
}
