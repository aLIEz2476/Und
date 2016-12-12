using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Ctrl_bef : MonoBehaviour {
    public float maxSpeed = 42.0f;
    bool facingLeft = true;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetBool("IsMove", true);
        transform.Translate(Vector3.left * move * 4f * Time.deltaTime);

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move < 0 && !facingLeft)
            Flip();
        else if (move > 0 && facingLeft)
            Flip();
        else
            anim.SetBool("IsMove", false);
	}

    void Flip()
    {
        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        facingLeft = !facingLeft;
    }
}
