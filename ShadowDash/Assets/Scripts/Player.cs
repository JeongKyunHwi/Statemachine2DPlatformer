using UnityEngine;

public class Player : Entity
{
    
    private float xInput;


    [Header("Move Info")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float JumpForce;

    [Header("Dash Info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashTime;

    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashCooldownTimer;

    [Header("Attack Info")]

    [SerializeField] private float comboTime = 0.3f;
    [SerializeField] private int comboCounter;
    private bool isAttacking;
    
    private float comboTimeWindow;
    

    
    

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        CheckInput();
        Movement();
        CollisionCheck();

        dashTime -= Time.deltaTime;
        dashCooldownTimer -= Time.deltaTime;
        comboTimeWindow -= Time.deltaTime;
       

        FlipController();
        AnimatorControllers();
    }

    public void AttackOver()
    {
        isAttacking = false;

        comboCounter++;

        if(comboCounter > 2)
        {
            comboCounter = 0;
        }
        
    }

    private void DashAbility()
    {
        if (dashCooldownTimer < 0 && !isAttacking)
        {
            dashCooldownTimer = dashCooldown;
            dashTime = dashDuration;
        }
    }

    

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartAttackEvent();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }
    }

    private void StartAttackEvent()
    {
        if (comboTimeWindow < 0)
        {
            comboCounter = 0;
        }
        isAttacking = true;
        comboTimeWindow = comboTime;
    }

    private void Movement()
    {
        if (isAttacking)
        {
            rb.linearVelocity = new Vector2(0, 0);
        }
        else if (dashTime > 0) // ´ë½ÃÁß
        {
            rb.linearVelocity = new Vector2(xInput * dashSpeed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocityY);
        }
    }

    private void Jump()
    {
        if (isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocityX, JumpForce);
    }

    private void AnimatorControllers()
    {
        bool isMoving = rb.linearVelocity.x != 0;
        anim.SetFloat("yVelocity", rb.linearVelocityY);
        anim.SetBool("IsMoving", isMoving);
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("IsDashing", dashTime > 0);
        anim.SetBool("IsAttacking", isAttacking);
        anim.SetInteger("comboCounter", comboCounter);

    }
    
    private void FlipController()
    {
        if (rb.linearVelocityX > 0 && !facingRight)
        {
            Flip();
        }
        else if (rb.linearVelocityX < 0 && facingRight)
        {
            Flip();
        }
    }
   
    protected override void CollisionCheck()
    {
        base.CollisionCheck();
    }
}
