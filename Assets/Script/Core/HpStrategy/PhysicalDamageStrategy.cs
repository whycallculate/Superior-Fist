public class PhysicalDamageStrategy : IDamageStrategy
{
    float physicalResist;

    public void SetResist(float resist)
    {
        physicalResist = resist;
    }

    public float CalculateDamage(float baseDamage)
    {
        if(physicalResist == 0) { return baseDamage; }

        float resistDamage = baseDamage * physicalResist;
        baseDamage -= resistDamage;
        return baseDamage;

    }


}