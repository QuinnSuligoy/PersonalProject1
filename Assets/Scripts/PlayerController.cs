using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horzInput;
    public float jumpForce;
    public bool grounded;
    public float BlinkUnits;
    public string Facing;
    private Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        //Get the Rigid Body
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
        //LeftRight
        if(horzInput > 0)
        {
            Facing = "Right";
        }
        else if(horzInput < 0)
        {
            Facing = "Left";
        }
        //Blink
        if(Input.GetKeyDown(KeyCode.E))
        {
            Blink();
        }
       

        
    }
    //Ground Check
    private void OnTriggerEnter2D(Collider2D collider)
    {  
        if(collider.tag == "Ground")
        {
            grounded = true;
        }
        if(collider.tag == "Lazer")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void Blink()
    {
        if(Facing == "Left")
        {
            transform.Translate(Vector2.left * BlinkUnits * Time.deltaTime);
        }
        else if(Facing == "Right")
        {
            transform.Translate(Vector2.right * BlinkUnits * Time.deltaTime);
        }
    }
}
