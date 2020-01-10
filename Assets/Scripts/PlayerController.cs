using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horzInput;
    public float jumpForce;
    public bool grounded;
    public string Facing;
    public float BlinkUnits;
    private Rigidbody2D playerRB;
    public float Health;
    public bool Invul;
    // Start is called before the first frame update
    void Start()
    {
        //Get the Rigid Body
        playerRB = GetComponent<Rigidbody2D>();
        Health = 100;
        StartCoroutine("InvulTimer");
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
        if (Input.GetKeyDown(KeyCode.E))
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
            if (Invul == false)
            {
                Health -= 10;
                Invul = true;
            }
        }
        if(collider.tag == "HealthPack")
        {
            Health += 50;
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
            transform.Translate(Vector2.left * BlinkUnits);
        }
        else if(Facing == "Right")
        {
            transform.Translate(Vector2.right * BlinkUnits);
        }
    }

    private IEnumerator InvulTimer()
    {
        while(true)
        {
            if(Invul == true)
            {
                yield return new WaitForSeconds(1);
                Invul = false;
            }
            yield return null;
        }
    }

   

    
}
