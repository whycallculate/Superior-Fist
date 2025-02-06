using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D rb;
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
        ChangeState(new CharacterIdleState(this));
    }
    private void FixedUpdate()
    {
        state.OnUpdate();
    }

    #region State
    private void HandleIdle()
    {
        ChangeState(new CharacterIdleState(this));
    }
    
    private void HandleWalk()
    {
        ChangeState(new CharacterWalkState(this));
    }

    private void HandleRun()
    {
        ChangeState(new CharacterRunState(this));
    }

    private void HandleDodge()
    {
        ChangeState(new CharacterDodgeState(this));
    }
    private void HandleAttack()
    {
        ChangeState(new CharacterAttackState(this));
    }

    void ChangeState(ICharacterState state)
    {
        if (this.state != null)
        {
            state.OnExit();
        }
        this.state = state;
        state.OnEnter();
    }
    #endregion
}
