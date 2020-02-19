using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject Lazer;
    public bool CanSee;
    public GameObject Blaster;
    public int speed = 5;
    public int EnemyHealth = 100; 
    
    // Start is called before the first frame update
    void Start()
    {
        CanSee = false;
        StartCoroutine("RepeatingFire");
    }

    // Update is called once per frame
    void Update()
    {
        //Turn The Blaster
        if(CanSee == true)
        {
            Blaster.transform.LookAt(Player.transform.position);
           
        }
        if(EnemyHealth <= 0)
        {
            Destroy(gameObject);
            Destroy(Blaster);
        }
    }
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CanSee = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CanSee = false;
        }
    }

    private void Fire()
    {
        Instantiate(Lazer, Blaster.transform.position, Blaster.transform.rotation);
    }
    private  IEnumerator RepeatingFire()
    {
        while(true)
        {

            if (CanSee == true)
            {
                yield return new WaitForSeconds(0.3f);
                Fire();
            }
            yield return null;
        }
        
       
    }
    public void TakeDmg(int dmgDone)
    {
        EnemyHealth -= dmgDone;
        Debug.Log("EnemyHealth:" + EnemyHealth);
    }
}
