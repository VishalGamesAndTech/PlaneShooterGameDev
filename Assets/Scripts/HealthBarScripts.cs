using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HealthBarScripts : MonoBehaviour
{
    public Transform Bar;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSize(float size)
    {
        Bar.localScale = new Vector2(size, 1f);
    }
    
      
    
}
