using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public ICharacterState state;


    private void OnEnable()
    {
        InputHandler.Instance.OnIdle += HandleIdle;
        InputHandler.Instance.OnWalk += HandleWalk;
        InputHandler.Instance.OnRun += HandleRun;
        InputHandler.Instance.OnDodge += HandleDodge;
        InputHandler.Instance.OnAttack += HandleAttack;
    }
    private void OnDisable()
    {
        InputHandler.Instance.OnIdle -= HandleIdle;
        InputHandler.Instance.OnWalk -= HandleWalk;
        InputHandler.Instance.OnRun -= HandleRun;
        InputHandler.Instance.OnDodge -= HandleDodge;
        InputHandler.Instance.OnAttack -= HandleAttack;
    }



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ChangeState(CharacterIdleState.Instance);
    }
    private void FixedUpdate()
    {
        state.OnUpdate();
    }

    #region State
    private void HandleIdle()
    {
        ChangeState(CharacterIdleState.Instance);
    }
    
    private void HandleWalk()
    {
        ChangeState(CharacterWalkState.Instance);
    }

    private void HandleRun()
    {
        ChangeState(CharacterRunState.Instance);
    }

    private void HandleDodge()
    {
        ChangeState(CharacterDodgeState.Instance);
    }
    private void HandleAttack()
    {
        ChangeState(CharacterDodgeState.Instance);
    }

    void ChangeState(ICharacterState state)
    {

        if (state == this.state) { return; }

        this.state?.OnExit();

        this.state = state;
        this.state?.OnEnter(this);
    }
    #endregion
}
