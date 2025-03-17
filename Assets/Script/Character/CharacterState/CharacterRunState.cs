using UnityEngine;

public class CharacterRunState : ICharacterState
{

    public static readonly CharacterRunState Instance = new CharacterRunState();


    private CharacterController player;
    private Rigidbody2D rb;
    private float moveSpeed = 150f;
    private float Horizontal;
    private float Vertical;
    private bool characterTurnLeft = true;

    public void OnEnter(CharacterController player)
    {
        this.player = player;
        rb = player.rb;
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        Horizontal = InputHandler.Instance.HorizontalInput;
        Vertical = InputHandler.Instance.VerticalInput;

        rb.velocity = new Vector2(Horizontal, Vertical) * (moveSpeed * Time.fixedDeltaTime);

        if(characterTurnLeft && Horizontal < 0)
        {
            rb.transform.Rotate(0, 180, 0);
        }
        else
        {
            rb.transform.Rotate(0, 0, 0);
        }
    }
}