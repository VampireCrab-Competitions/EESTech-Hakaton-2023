using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characters : MonoBehaviour
{
    [SerializeField]
    protected int health;

    [SerializeField]
    protected int armor;

    [SerializeField]
    protected int mana;

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
}
