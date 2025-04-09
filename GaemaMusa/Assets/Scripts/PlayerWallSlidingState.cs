using UnityEngine;

public class PlayerWallSlidingState : PlayerState
{
    public PlayerWallSlidingState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJump);
            return;
        }

        if (xInput != 0)
        {
            if (player.facingDir != xInput)
            {
                stateMachine.ChangeState(player.idleState);
            }
        }
        if (yInput < 0)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocityY * 0.8f);
        }
        if (player.isGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
