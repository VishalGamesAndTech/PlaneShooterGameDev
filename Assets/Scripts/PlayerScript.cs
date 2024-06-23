using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 10f;
    float minX;
    float maxX;
    float minY;
    float maxY;
   float padding = 0.8f;
        
    // Start is called before the first frame update
    void Start()
    {
        findBundaries();
    }
    void findBundaries()
    {
        Camera mainCamera = Camera.main;
        minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }


    // Update is called once per frame
    void Update()
    {
        //float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;


        //float newXpos = Mathf.Clamp(transform.position.x + deltaX, minX, maxX);
       
        //float newYpos = Mathf.Clamp(transform.position.y + deltaY, minY, maxY);
     

        //transform.position = new Vector2(newXpos, newYpos);

        if (Input.GetMouseButton(0))
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));   
            transform.position = Vector2.Lerp(transform.position, newPos, speed*Time.deltaTime);
        }

 
    }   
}
