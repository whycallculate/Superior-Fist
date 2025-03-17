using System;
using System.Collections;
using UnityEngine;

public class CharacterCore : MonoBehaviour, IDamageble
{
    

    [SerializeField] HpBase characterHP;
    public event Action CharacterTakeDamage;
    private void Awake()
    {
        characterHP = GetComponent<HpBase>();
    }



    private void Update()
    {
        Debug.Log(characterHP.currentHp);
    }

    public void TakeDamage(float damage, DamageEnum damageType)
    {
        characterHP.TakeDamageHp(damage, damageType);
        CharacterTakeDamage?.Invoke();
        

    }

}