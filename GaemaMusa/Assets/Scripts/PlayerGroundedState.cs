using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
        : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();

        if (!player.isGroundDetected())
        {
            stateMachine.ChangeState(player.airState);
        }
        if (Input.GetKeyDown(KeyCode.Space) && player.isGroundDetected())
        {
            stateMachine.ChangeState(player.jumpState);
        }

    }

    public override void Exit()
    {
        base.Exit();
    }


}
