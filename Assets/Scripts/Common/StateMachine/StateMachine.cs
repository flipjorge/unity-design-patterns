public class StateMachine<T>
{
    private State<T> _currentState;

    public void ChangeTo(State<T> state)
    {
        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState?.Update();
    }
}