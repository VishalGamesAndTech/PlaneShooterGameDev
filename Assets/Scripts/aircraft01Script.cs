using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class aircraft01Script : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public Transform[] spownPoint;

    public GameObject Choin;
    public GameObject flash;
    public float BulletSpawnTime = 1f;
    public GameObject EnemyExploision;
    public HealthBarScripts healthBar;
    public float health = 5f;
    public GameObject DamageEffect;
    float barSize = 1f;
    float damage = 0;
    public AudioSource audioSource;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioClip bulletSound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
        flash.SetActive(false);
        damage = barSize / health;
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate( Vector2.down * speed * Time.deltaTime );
    }
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            audioSource.PlayOneShot(damageSound, 0.5f);
            damageHelthBar();
            Destroy(collision.gameObject);
            GameObject damageEffect =  Instantiate(DamageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageEffect, 0.1f);

            if (health <= 0)
            {
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                GameObject enemyExploision = Instantiate(EnemyExploision, transform.position, Quaternion.identity);
                Destroy(enemyExploision, 0.4f);
                Instantiate(Choin, transform.position, quaternion.identity);
            }
           
        }
      }
    void damageHelthBar()
    {
        if( health > 0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthBar.SetSize(barSize);

        }
    }

        void Fair()
    {
        for (int i = 0; i < spownPoint.Length; i++)
        {
            Instantiate(bullet, spownPoint[i].position, Quaternion.identity);
        }
        //Instantiate(bullet, spownPint01.position, Quaternion.identity);
        //Instantiate(bullet, spownPint02.position, Quaternion.identity);

    }
    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(BulletSpawnTime);
            Fair();
            audioSource.PlayOneShot(bulletSound, 0.5f);
            audioSource.Play();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            flash.SetActive(false);
        }
    }
}
