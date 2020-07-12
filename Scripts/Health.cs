using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite Life;

    public void SetMaxHealth(int health)
    {
        numOfHearts = health;
    }

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }

        }
    }
}
