public class CharacterStateTransition
{
    private ICharacterState currentState;

    public void ChangeState(ICharacterState newState)
    {

        if (currentState != null)
        {
            currentState.OnExit();
        }

        currentState = newState;
        currentState.OnEnter();

    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate();
        }
    }
}