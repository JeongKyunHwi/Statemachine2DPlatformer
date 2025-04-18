using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
        : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(player.isGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
        if (player.isWallDetected())
        {
            stateMachine.ChangeState(player.slidingState);
        }
        if(xInput != 0)
        {
            player.SetVelocity(player.moveSpeed * 0.8f * xInput, rb.linearVelocityY);
        }

    }
}
