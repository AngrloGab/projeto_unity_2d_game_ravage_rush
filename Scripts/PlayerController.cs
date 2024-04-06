using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float move_speed;
    public float jump_speed;
    // Start is called before the first frame update
    private Rigidbody2D rig;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public bool isJumping;

    public float points = 0;
    public Text scoreText;

    public GameObject GameOver;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        Attack();
        Move();
        Jump();
        
    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * move_speed;
    }

    void Jump(){
        
        
        if(Input.GetKeyDown(KeyCode.W) && !isJumping){
            rig.AddForce(new Vector2(0f,jump_speed), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 9){
            isJumping = false;
        }
        if(collision.gameObject.layer == 11){
            GameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void OnCollisionExit2D(Collision2D collision){
         if(collision.gameObject.layer == 9){
            isJumping = true;
        }
    }

    

    void Attack(){
        if (Input.GetKeyDown(KeyCode.Space)){
        
            animator.SetTrigger("Attack");

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach(Collider2D enemy in hitEnemies){
                enemy.GetComponent<Frog>().Devour();
                points+=1;
                scoreText.text = "Points: " + points.ToString();
            }
        }
    }

    void OnDrawGizmosSelected(){
       if(attackPoint == null){  return;}
          
       Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}