using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 7;
    public Rigidbody rb;
    public bool canShoot = true;
    public bool secundary = false;
    public float timeBtwnShoot = 3f;
    public float timer = 0f;
    public Transform firePoint;
    public Skill_SO skill;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed,
            rb.velocity.y,
            Input.GetAxis("Vertical")* speed);
        Shoot();
    }

    void Shoot()
    {
        if (timer < timeBtwnShoot)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(skill.ProyectilePreFab, firePoint.position,firePoint.rotation);
                timer = 0;
            }
        }
    }
    public void ShootAlternative(Skill_SO alternative)
    {
        Instantiate(alternative.ProyectilePreFab, firePoint.position, firePoint.rotation);
    }

    
}
