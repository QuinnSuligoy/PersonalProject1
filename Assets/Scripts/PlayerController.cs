using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horzInput;
    public float jumpForce;
    public bool grounded;
    private Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        //Get the Rigid Body
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get inputs
        horzInput = Input.GetAxis("Horizontal");
        //Move the player left/right
        transform.Translate(Vector2.right * horzInput * speed * Time.deltaTime);
        //Juuuump
        if(grounded == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                playerRB.AddForce(Vector2.up * jumpForce);
            }
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
