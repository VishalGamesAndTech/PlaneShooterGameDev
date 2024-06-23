using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject DamageEffect;
    public PlayerHealthBar playerHealthBar;
    public Transform spownPint01;
    public Transform spownPint02;
    public GameObject flash;
    public float BulletSpawnTime = 1f;
    public GameObject playerExploision;
    public float health = 20f;
    float barFillAmount = 1f;
    float damage = 0;
    public coinCountScript CoinCount;
    public GameContolScript gameContolScript;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip explosionSound;
    public AudioClip coinSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
        flash.SetActive(false);
        damage = barFillAmount / health;
    }

    // Update is called once per frame

    void Update()
    {

       

    }
    void Fair()
    {
       
        Instantiate(bullet, spownPint01.position, Quaternion.identity);
        Instantiate(bullet, spownPint02.position, Quaternion.identity);

    }
    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(BulletSpawnTime);
            Fair();
            audioSource.Play();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            flash.SetActive(false);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            audioSource.PlayOneShot(audioClip, 0.5f);
            damagePlayerHealthBar();
            Destroy(collision.gameObject);
            GameObject damageEffect = Instantiate(DamageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageEffect, 0.1f);
            if (health <= 0)
            {
                gameContolScript.GameOver();
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                GameObject PlayerExploision = Instantiate(playerExploision, transform.position, Quaternion.identity);
                Destroy(PlayerExploision, 0.4f);
            }
          
        }
        if (collision.gameObject.tag == "coin")
        {
            CoinCount.AddCount();
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(coinSound, 0.5f);
        }
    }
    
     void damagePlayerHealthBar()
    {
       if (health > 0)
        {
            health -= 1f;
            barFillAmount = barFillAmount - damage;
            playerHealthBar.SetAmount(barFillAmount);

        }
        

    }
   
           
 }
    
  



