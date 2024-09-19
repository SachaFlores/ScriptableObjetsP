using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public List<Skill_SO> skills = new List<Skill_SO>();
    private int currentSkillIndex = 0;
    public UiControler uiControler;

    void Update()
    {
        // Utiliza el primer SKILL cuando se presiona el botón derecho del mouse
        if (Input.GetMouseButtonDown(1) && skills.Count > 0)
        {
            UseSkill(skills[currentSkillIndex]);
        }

        // Cambia el índice del skill actual con la rueda del mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            // Scroll hacia arriba, avanza al siguiente skill
            currentSkillIndex = (currentSkillIndex + 1) % skills.Count;
        }
        else if (scroll < 0f)
        {
            // Scroll hacia abajo, retrocede al skill anterior
            currentSkillIndex = (currentSkillIndex - 1 + skills.Count) % skills.Count;
        }

        // Opcional: Actualiza la interfaz de usuario para mostrar el skill seleccionado
        UpdateUI();
    }

    void UseSkill(Skill_SO skill)
    {
        Player p = gameObject.GetComponent<Player>();
        skills.RemoveAt(currentSkillIndex);
        p.ShootAlternative(skill);
    }

    void UpdateUI()
    {
        uiControler.actualizar(currentSkillIndex);
    }

    public void addSkill(Skill_SO skillToAdd)
    {
        skills.Add(skillToAdd);
    }

}
