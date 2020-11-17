using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    public Transform cT;

    public float bSpeed = 0;
    public float maxDistance;

    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cT = FindObjectOfType<Camera>().transform;
    }

    Vector2 bulletDirection;
    public void GetDirection(Transform muzzle)
    {
        bulletDirection = muzzle.up;
    }

    void Update()
    {
        rb.velocity = bulletDirection * Time.deltaTime * bSpeed;

        CheckDistance();

    }

    Vector2 distanceFromCamera;
    void CheckDistance()
    {
        distanceFromCamera = transform.position - cT.position;

        if (distanceFromCamera.magnitude > maxDistance)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<Meteor_Script>().hp = collision.transform.GetComponent<Meteor_Script>().hp - 1;
        }
        Destroy(gameObject);

    }
}
