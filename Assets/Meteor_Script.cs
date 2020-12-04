using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Script : MonoBehaviour
{
    public Rigidbody2D rb;
    [Space(10)]
    public int pointsWorth;
    public int hp;
    public int size = 0;
    public float speed;
    [Space(10)]
    public GameObject mediumMeteor;
    public GameObject smallMeteor;
    public GameObject particleSystem;

    [Space(10)]
    public Transform graphic;
    public float speedRotate;

    private Game_Manager g_m;
    private void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        g_m = GameObject.FindObjectOfType<Game_Manager>();

    }

    void Update()
    {
        rb.velocity = transform.up * Time.deltaTime * speed;
        if (hp <= 0)
        {
            //meteor go bye bye
            g_m.score = g_m.score + pointsWorth;
            SpawnMeteors();
            Instantiate(particleSystem, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
        graphic.Rotate(0, 0, speedRotate);
    }

    GameObject clone;
    void SpawnMeteors()
    {
        if (size == 2)
        {
            FindObjectOfType<AudioManager>().Play("Huge Explosion");

            for (int i = 0; i < 2; i++)
            {
                int ranAng = Random.Range(0, 360);
                clone = Instantiate(mediumMeteor, transform.position, Quaternion.Euler(0, 0, ranAng));
            }
        }

        if (size == 1)
        {
            FindObjectOfType<AudioManager>().Play("Small Explosion");

            for (int i = 0; i < 4; i++)
            {
                int ranAng = Random.Range(0, 360);
                clone = Instantiate(smallMeteor, transform.position, Quaternion.Euler(0, 0, ranAng));
            }
        }

        if (size == 0)
        {
            FindObjectOfType<AudioManager>().Play("Small Explosion");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
