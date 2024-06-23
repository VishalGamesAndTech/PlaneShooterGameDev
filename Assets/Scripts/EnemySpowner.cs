using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpowner : MonoBehaviour
{
    public GameObject[] Enemys;
    public float time= 2f;
    public int enemyNum = 5;
    public GameContolScript gameContol;
    private bool lastEnemySpown;
  
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemySpowner());
    }

    // Update is called once per frame
    void Update()
    {
        if (lastEnemySpown && FindObjectOfType<aircraft01Script>() == null && FindObjectOfType<En>() == null) 
        {
            StartCoroutine(gameContol.LevelComplete());
            

        }
       
    }
    IEnumerator enemySpowner()
    {
        for (int i = 0; i < enemyNum; i++)
        {
            yield return new WaitForSeconds(time);
            spownEnemy();

        }
       
        lastEnemySpown = true;



    }
    void spownEnemy()
    {
        int randomRange = Random.Range(0, Enemys.Length);
        int randomPosition = Random.Range(2, -2);
        Instantiate(Enemys[randomRange],new Vector2(randomPosition,transform.position.y),Quaternion.identity);  
    }
}
