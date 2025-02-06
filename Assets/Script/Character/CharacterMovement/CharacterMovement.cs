using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D characterRb;
    float currentSpeed;
    public float walkSpeed;
    public float runSpeed;
    public bool isDodge;

    private void Awake()
    {
        characterRb = GetComponent<Rigidbody2D>();
    }

    public void WalkCharacter()
    {

    }
    public void RunCharacter()
    {

    }




}
