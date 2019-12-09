using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    private Vector3 Offset = new Vector3(-1.467794f, -0.7f, -10);
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        //Move The Camera
        transform.position = Player.transform.position + Offset;
    }
}
