using UnityEngine;

public class enemy : MonoBehaviour
{

    int moveSpeed = 3;
    int direction = -1;

    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D bc;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.linearVelocityX = moveSpeed * direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Invert"))
        {
            direction *= -1;
            transform.localScale = new Vector3(1,1,1);
        }
        if (collision.gameObject.CompareTag("Reverse"))
        {
            direction *= -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        

    }
   

}
