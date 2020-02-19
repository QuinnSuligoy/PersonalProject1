using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int dmg = 10;
    public bool InHurtBox = false;
    private Enemy EnemyScript; 
    // Start is called before the first frame update
    void Start()
    {
        EnemyScript = GameObject.Find("Enemy").GetComponent<Enemy>();
        StartCoroutine("Damage");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyHurtBox"))
        {
            Debug.Log("InHurtBox");
            InHurtBox = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyHurtBox"))
        {
            InHurtBox = false;
        }
    }

    private IEnumerator Damage()
    {
        while(true)
        {
            if (Input.GetMouseButtonDown(0) && InHurtBox)
            {
                EnemyScript.TakeDmg(dmg);
                yield return new WaitForSeconds(0.5f);
            }
            yield return null;
        }
    }
}
