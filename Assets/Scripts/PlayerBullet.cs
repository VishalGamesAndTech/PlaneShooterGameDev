using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0f, speed * Time.deltaTime, 0f);

       // transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
