using UnityEngine;

public class Character_Ctrl : MonoBehaviour {
    public float maxSpeed = 120.0f;
    bool facingLeft = true;
    public float maxHeight, flapVelocity;
    
    Animator anim;
    public Rigidbody2D myRigibody { get; set; }
    
    public bool canMove;
    public Vector3 moveVector { get; set; }

    public Joypad joypad;
    
    
	// Use this for initialization
	void Start () {
        System.GC.Collect();
        anim = GetComponent<Animator>();
        moveVector = new Vector3(0, 0, 0);
        myRigibody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!canMove)
        {
            return;
        }
        HandleInput();
        move();
        EaseVelocity();
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
    public void attack()
    {
        anim.Play("main_character_attack");
    }

    
    public void move()
    {
        float moveWhere = Input.GetAxis("Horizontal");

        

        anim.SetFloat("Speed", Mathf.Abs(moveWhere));
        anim.SetBool("IsMove", true);




        if (Input.GetKey(KeyCode.LeftArrow)||joypad.inputVector.x>0)
        {
            transform.Translate(Vector3.left * moveWhere * 4f * Time.deltaTime);
            anim.Play("main_character_walk");
        }
        if (Input.GetKey(KeyCode.RightArrow)||joypad.inputVector.x<0)
        {
            transform.Translate(Vector3.right * moveWhere * 4f * Time.deltaTime);
            anim.Play("main_character_walk");
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(joypad.inputVector.x * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (((moveWhere > 0|| joypad.inputVector.x > 0) && !facingLeft)|| ((moveWhere < 0 || joypad.inputVector.x < 0) && facingLeft))
            Flip();
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.Play("main_character_attack");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftControl)||joypad.inputVector.y == 0)
        {
            anim.SetFloat("Speed", 0);
            anim.Play("main_character_stand");
        }
       
    }
    public void HandleInput()
    {
        moveVector = PoolInput();
    }

    public Vector3 PoolInput()
    {
        Vector3 direction = Vector3.zero;

        direction.x = joypad.GetHorizontalValue();
        direction.y = joypad.GetVerticalValue();

        if (direction.sqrMagnitude > 1)
        {
            direction.Normalize();
        }
        return direction;
    }
    public void EaseVelocity()
    {
        Vector3 easeVelocity = myRigibody.velocity;
        easeVelocity.x *= 0.75f;
        easeVelocity.y *= 0.75f;
        easeVelocity.z *= 0.0f;
        //anim.SetFloat("Speed", 0);
        //anim.Play("main_character_stand");
        myRigibody.velocity = easeVelocity;
    }
    public void Jump()
    {
        GetComponent<Rigidbody2D>().MovePosition(transform.position + Vector3.up * 100f);
        //GetComponent<Rigidbody2D>().AddForce(Vector2.up * Time.deltaTime * 100.0f, ForceMode2D.Force);
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        facingLeft = !facingLeft;   
    }
    
}
