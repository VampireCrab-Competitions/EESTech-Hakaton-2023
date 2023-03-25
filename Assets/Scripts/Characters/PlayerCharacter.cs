using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {

    }

    
}
