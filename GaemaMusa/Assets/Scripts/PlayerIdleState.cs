using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
        : base(_player, _stateMachine, _animBoolName) //생성자를 이용한 빠른 초기화
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.N))
        {
            player.stateMachine.ChangeState(player.moveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
