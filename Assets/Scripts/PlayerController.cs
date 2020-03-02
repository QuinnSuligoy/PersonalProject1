using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GroundCheck GroundChecker;
    private Rigidbody2D playerRB;
    public WallCheck WallCheck;

    public PhysicsMaterial2D PhysicMat;

    public float speed;
    public float horzInput;
    public float jumpForce;
    public float BlinkUnits;
    public float Health;
    public float Velocity;
    public float wallJumpForce;

    public bool Invul;

    public string Facing;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Get the Rigid Body
        playerRB = GetComponent<Rigidbody2D>();
        GroundChecker = GameObject.Find("GroundChecker").GetComponent<GroundCheck>();
        WallCheck = GameObject.Find("WallDetecor").GetComponent<WallCheck>();
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
        //Blink
        if (Input.GetKeyDown(KeyCode.E))
        {
            Blink();
        }

        //WallCheckAndSlide
        if(WallCheck.TouchingWall)
        {
            if (!Input.GetKeyDown(KeyCode.Space))
            {
                playerRB.velocity = playerRB.velocity / 5;
            }
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
            if (!WallCheck.TouchingWall)
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
                        playerRB.gravityScale = 2;
                        playerRB.velocity = Vector2.zero;
                        playerRB.AddForce(Vector2.up * jumpForce);
                        GroundChecker.secondJump = false;
                    }
                }
            }
            else if(WallCheck.TouchingWall)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    if(Facing == "Left")
                    {
                        playerRB.AddForce(new Vector2(-0.5f, 0) * wallJumpForce, ForceMode2D.Impulse);
                        playerRB.AddForce(new Vector2(0, 0.5f) * wallJumpForce, ForceMode2D.Impulse);
                        Facing = "Right";

                    }
                    else if(Facing == "Right")
                    {
                        playerRB.AddForce(new Vector2(-0.5f,0) * wallJumpForce, ForceMode2D.Impulse);
                        playerRB.AddForce(new Vector2(0,0.5f) * wallJumpForce, ForceMode2D.Impulse);
                        Facing = "Left";
                    }
                            
                }
            }  
            yield return null;
        }
    }

    
}
