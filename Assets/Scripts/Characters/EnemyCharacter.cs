using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    private int health;

    private int armor;

    private int mana;

    private EnemyCharacter()
    {
        health = (int)(100 * Random.Range(0.1f, 2f));
        armor = 0;
        mana = 0;
    }

    public int GetHealth()
    {
        return health;
    }
    
    public void SetHealth(int health)
    {
        this.health = health;
    }

    public int GetMana()
    {
        return mana;
    }
    
    public void SetMana(int mana)
    {
        this.mana = mana;
    }
    
    public int GetArmor()
    {
        return armor;
    }

    public void SetArmor(int armor)
    {
        this.armor = armor;
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            EnemyKilled();
        }
    }

    public void EnemyKilled()
    {
        Destroy(gameObject);
    }
}
