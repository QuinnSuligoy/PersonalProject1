using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horzInput;
    public float jumpSpeed;
    public float jumpInput;
    public bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get inputs
        horzInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxis("Jump");
        //Move the player left/right
        transform.Translate(Vector2.right * horzInput * speed * Time.deltaTime);
        //Juuuump
        if(grounded == true)
        {
            transform.Translate(Vector2.up * jumpInput * jumpSpeed * 0.3f);
        }
       

        
    }
    //Ground Check
    private void OnTriggerEnter2D(Collider2D collider)
    {  
        if(collider.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "Ground")
        {
            grounded = false;
        }
    }
}
