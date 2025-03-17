using UnityEngine;
public class HpBase : IDamageble
{
    
    public int statHp;
    public float maxHp;
    public float currentHp;

    [Space]
    [Space]
    // 0.1 resist = %10
    public float physicalResist = 0;
    public float magicResist = 0;
    [Space]
    [Space]
    public bool isDead = false;


    IDamageStrategy damageStrategy;


    public HpBase(IDamageStrategy damageStrategy)
    {
  
        this.damageStrategy = damageStrategy;
        currentHp = maxHp;
    }
    public void SetMaxHp(int statHp)
    {
        if (statHp <= 0) { return; }

        this.statHp += statHp;
        maxHp = this.statHp * maxHp;

        if(maxHp < currentHp) 
            currentHp = maxHp;

    }

    public void AddCurrentHp(int addHp)
    {

        if ((currentHp + addHp) < 0) { return; }
        if ((currentHp + addHp) > maxHp) { currentHp = maxHp; }
        if ((currentHp + addHp) <= maxHp) { currentHp += addHp; }
    }

    public void RemoveCurrentHp(int removeHp)
    {
        if (currentHp - removeHp >= maxHp) { return; }
        if (currentHp - removeHp < maxHp)
        {
            currentHp = 0;
            isDead = true;

        }
    }

    public void TakeDamageHp(float damage)
    {

        float finalDamage = damageStrategy.CalculateDamage(damage);
        currentHp -=finalDamage;

    }


}