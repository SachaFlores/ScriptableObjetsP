using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Windows.Speech;
using static Skill_SO;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 7;
    public float life = 5;
    public Skill_SO skill;
    public GameObject item;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position ;
        float anguloY = Mathf.Atan2 (dir.x, dir.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, anguloY, 0);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    public void TakeDamage(float damage)
    {
        life += - damage;
        if(life <= 0)
        {
            if(Random.Range(0,4)==1)
            {
                Instantiate(item, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("me chocaron");
            Destroy(gameObject);
        }
    }

}
