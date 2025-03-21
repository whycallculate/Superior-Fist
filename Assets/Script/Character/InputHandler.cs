using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    #region singleton
    public static InputHandler instance;
    public static InputHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InputHandler>();
            }
            return instance;

        }



    }

    #endregion

    public event Action OnIdle;
    public event Action OnWalk;
    public event Action OnRun;
    public event Action OnDodge;
    public event Action OnAttack;


    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }
    public bool IsDodge { get; private set; }
    public bool IsAttack { get; private set; }


    public float DodgeCooldown = 1;
    public float AttackCooldown = 1;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        StartCoroutine(DodgeInput());
        StartCoroutine(AttackInput());
        WalkOrRunInput();
    }
    

    private IEnumerator DodgeInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsAttack)
        {
            IsDodge = true;
            OnDodge?.Invoke();

            yield return new WaitForSeconds(DodgeCooldown);

            IsDodge = false;
        }
    }
    private IEnumerator AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !IsDodge)
        {
            IsAttack = true;
            OnAttack?.Invoke();
            yield return new WaitForSeconds(AttackCooldown);
            IsAttack = false;

        }
    }

    private void WalkOrRunInput()
    {
        if(HorizontalInput != 0 || VerticalInput != 0 )
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                OnRun?.Invoke();
            }
            else
            {
                OnWalk?.Invoke();

            }
        }
        else
        {
            OnIdle?.Invoke();
        }
    }
}
