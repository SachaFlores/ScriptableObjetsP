using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Skill_SO skill;
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            SkillManager skillManager = other.GetComponent<SkillManager>();
            skillManager.addSkill(skill);
            Destroy(gameObject);
        }
    }
}
