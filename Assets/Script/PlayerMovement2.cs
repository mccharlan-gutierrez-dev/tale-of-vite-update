using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement2 : MonoBehaviour
{
    public float moveSpeed;

    Rigidbody2D rb;
    Animator anim;

    float horizontal, vertical;

    public Transform attackPoint;
    public float attackRange = 0.5f;

    private Inventory inventory;
    [SerializeField] private UI_inventory uiInventory;

    private void Awake()
    {
        inventory = new Inventory();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //uiInventory.SetInventory(inventory);

        //ItemWorld.SpawnItemWorld(
        //    new Vector3(15, -6),
        //    new Item
        //    {
        //        itemType = Item.ItemType.HealthPotion,
        //        amount = 1
        //    }
        //);

        //ItemWorld.SpawnItemWorld(
        //    new Vector3(10, -4),
        //    new Item
        //    {
        //        itemType = Item.ItemType.Coin,
        //        amount = 1
        //    }
        //);

        //ItemWorld.SpawnItemWorld(
        //    new Vector3(10, -6),
        //    new Item
        //    {
        //        itemType = Item.ItemType.Medkit,
        //        amount = 1
        //    }
        //);

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal < 0)
            transform.localScale = new Vector2(-1, 1);
        else if (horizontal > 0)
            transform.localScale = new Vector2(1, 1);

        if (horizontal != 0 || vertical != 0)
            anim.SetBool("IsRunning", true);
        else
            anim.SetBool("IsRunning", false);

        if (Input.GetMouseButtonDown(0))
        {
            Attack1();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Attack2();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("IsGuarding", true);
        }
        else
        {
            anim.SetBool("IsGuarding", false);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = horizontal * moveSpeed;
        rb.linearVelocityY = vertical * moveSpeed;
    }

    void Attack1()
    {
        anim.SetTrigger("Attack1");
        Attack();
    }

    void Attack2()
    {
        anim.SetTrigger("Attack2");
        Attack();
    }

    void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(
            attackPoint.position,
            attackRange
        );

        foreach (Collider2D enemy in enemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Destroy(enemy.gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(
            attackPoint.position,
            attackRange
        );
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();

        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
        }
    }

}
