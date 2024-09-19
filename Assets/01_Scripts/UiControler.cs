using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UiControler : MonoBehaviour
{
    public List<Image> elementos = new List<Image>();
    public List<Image> elemento2 = new List<Image>();
    public void actualizar(int selected)
    {
        foreach (Image item in elementos)
        {
            item.color = Color.yellow;
        }
        elementos[selected].color = Color.red;
    }
}
