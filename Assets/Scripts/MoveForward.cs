using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 90, 0);
        StartCoroutine("Despawn");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime );
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
