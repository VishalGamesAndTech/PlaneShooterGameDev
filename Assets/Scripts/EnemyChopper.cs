using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class En : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public Transform spownPoint;
    public float BulletSpawnTime = 1f;
    public GameObject flash;
    public GameObject EnemyExploision;
    public float health = 5f;
    float barSize = 1f;
    float damage = 0;
    public HealthBarScripts healthBar;
    public GameObject DamageEffect;
    public GameObject Choin;
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
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
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
                Instantiate(Choin, transform.position,quaternion.identity);


            }

        }
    }
    void damageHelthBar()
    {
        if (health > 0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthBar.SetSize(barSize);


        }


    }



    void Fair()
    {
        Instantiate(bullet,spownPoint.position,Quaternion.identity);
    }
    IEnumerator Shoot()
    {

        while (true)
        {
            yield return new WaitForSeconds(BulletSpawnTime);
            Fair();
            audioSource.PlayOneShot(bulletSound, 0.5f);
            flash.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            flash.SetActive(false);
        }
    }
       
}
