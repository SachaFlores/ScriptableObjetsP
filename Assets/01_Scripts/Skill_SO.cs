using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObject/Skill")]
public class Skill_SO : ScriptableObject
{
    public string skillName;

    public DamageType damageType;

    public float duration;

    public GameObject ProyectilePreFab;
    public enum DamageType
    {
        normal = 0,
        fire = 1,
        Ice = 2,
        wind = 3,
        dark = 4,
        light = 5
    }
}
