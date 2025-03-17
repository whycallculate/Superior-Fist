public class MagicDamageStrategy : IDamageStrategy
{
    float magicResist;
    public void SetResist(float resist)
    {
        magicResist = resist;
    }

    public float CalculateDamage(float baseDamage)
    {
        if (magicResist == 0) { return baseDamage; }

        float resistDamage = baseDamage * magicResist;
        baseDamage -= resistDamage;
        return baseDamage;





    }
}