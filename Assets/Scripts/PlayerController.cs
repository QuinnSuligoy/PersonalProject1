using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horzInput;
    public float jumpForce;
    public string Facing;
    public float BlinkUnits;
    private Rigidbody2D playerRB;
    public float Health;
    public bool Invul;
    public float Velocity;
    private float realJumpForce;
    public GroundCheck GroundChecker;
    // Start is called before the first frame update
    void Start()
    {
        //Get the Rigid Body
        playerRB = GetComponent<Rigidbody2D>();
        GroundChecker = GameObject.Find("GroundChecker").GetComponent<GroundCheck>();
        Health = 100;
        StartCoroutine("InvulTimer");
        StartCoroutine("Jump");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Velocity = playerRB.velocity.y;
        //Get inputs
        horzInput = Input.GetAxis("Horizontal");
        //Move the player left/right
        transform.Translate(Vector2.right * horzInput * speed * Time.deltaTime);
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
        if (collider.tag == "Lazer")
        {
            if (Invul == false)
            {
                Health -= 10;
                Invul = true;
            }
        }
        if (collider.tag == "HealthPack")
        {
            Health += 50;
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

   private IEnumerator Jump()
    {
        while (true)
        {
            if (GroundChecker.grounded == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    playerRB.AddForce(Vector2.up * jumpForce);
                }
            }
            else if (GroundChecker.grounded == false && GroundChecker.secondJump == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    playerRB.velocity = Vector2.zero;
                    playerRB.AddForce(Vector2.up * jumpForce);
                    GroundChecker.secondJump = false;
                }
            }
            yield return null;
        }
    }

    
}
