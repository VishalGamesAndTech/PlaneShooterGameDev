using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCountScript : MonoBehaviour
{
    public Text coinCountText;
    int count = 0;
    public Text coinText;
    public Text coinText02;
 
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        coinCountText.text = count.ToString();
        coinText.text = "COIN : "+count.ToString();
        coinText02.text = "COIN : "+count.ToString();
    }
    public void AddCount()
    {
        count++;
    }
    
   
}
