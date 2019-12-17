using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime );
        IEnumerator LoseTime()
        {
            while(true)
            {
                yield return new WaitForSeconds(1.5f);
                Destroy(gameObject);
            }
        }
        
    }
}
