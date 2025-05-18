using System;
using UnityEngine;

namespace OneQuiveri
{
    public abstract class StateMachine
    {
        protected IState _currentState;

        public IState currentState => _currentState;

        public event Action<IState> stateChanged;

        public void Initialize(IState state)
        {
            _currentState = state;

            _currentState.Enter();

            stateChanged?.Invoke(state);
        }

        public void SetState(IState state)
        {
            if (!_currentState.CanTransitionTo(state))
            {
                return;
            }

            _currentState.Exit();

            _currentState = state;

            _currentState.Enter();

            stateChanged?.Invoke(state);
        }

        public void HandleState()
        {
            if (_currentState != null)
            {
                _currentState.Handle();
            }
        }
    }
}