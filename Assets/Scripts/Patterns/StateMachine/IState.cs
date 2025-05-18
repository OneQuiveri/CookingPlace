using UnityEngine;

namespace OneQuiveri
{
    public interface IState
    {
        public bool CanTransitionToItself { get; }

        public void Enter();
        public void Handle();
        public void Exit();

        public bool CanTransitionTo(IState state);
    }
}