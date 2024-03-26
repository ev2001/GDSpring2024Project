using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Creature : MonoBehaviour
{
    [Header("Stats")]
    //[SerializeField] int health = 3;
    public float speed = 0f;
    [SerializeField] int health = 3;
    [SerializeField] int stamina = 3;
    // private int currentLives; // Current number of lives

    public enum CreatureMovementType {tf, physics};
    [SerializeField] CreatureMovementType movementType = CreatureMovementType.tf;

    [Header("Flavor")]
    [SerializeField] string creatureName = "SchoolGirl";
    public GameObject body;
    [SerializeField] private List<AnimationStateChanger> animationStateChangers;

    [Header("Tracked Data")]
    [SerializeField] Vector3 homePosition = Vector3.zero;
    public CreatureSO creatureSO;

    //[SerializeField] GameObject box;


    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    //Start is called before the first frame update
    void Start()
    {
        //currentLives = 2;
        Debug.Log(health);

        //  SpriteRenderer sr = box.GetComponent<SpriteRenderer>();
        //  sr.color = Color.black;
    }

    // public void DecreaseLives(int amount)
    // {
    //     currentLives -= amount;
    //     if (currentLives <= 0) 
    //     {
    //         RespawnOrMainMenu();
    //     }
    // }

    // private void RespawnOrMainMenu()
    // {
    //     SceneManager.LoadScene("MainMenu");
    // }

    //Update is called once per frame
    void Update()
    {
        if(creatureSO != null){
            creatureSO.health = health;
            creatureSO.stamina = stamina;
        }
    }

    void FixedUpdate(){

    }

    public void MoveCreature(Vector3 direction)
    {
       if(movementType == CreatureMovementType.tf)
       {
            MoveCreatureTransform(direction);
       }
       else if(movementType == CreatureMovementType.physics)
       {
            MoveCreatureRb(direction);
       }

       //set animation
       if(direction.x != 0)
       {
        foreach(AnimationStateChanger asc in animationStateChangers)   
        {
            asc.ChangeAnimationState("Walk");
        } 
       }else{
                foreach(AnimationStateChanger asc in animationStateChangers){
                    asc.ChangeAnimationState("Idle");
                }
            }
    }

    public void MoveCreatureToward(Vector3 target){
        Vector3 direction = target - transform.position;
        MoveCreature(direction.normalized);
    }

    public void Stop(){
        MoveCreature(Vector3.zero);
    }

    public void MoveCreatureRb(Vector3 direction){
        Vector3 currentVelocity = new Vector3(0, 0, 0);
        rb.velocity = currentVelocity + (direction * speed);
        //rb.velocity = direction * speed;
        if(rb.velocity.x < 0)
        {
            body.transform.localScale = new Vector3(-1,1,1);
        }else if(rb.velocity.x > 0){
            body.transform.localScale = new Vector3(1,1,1);
        }
       //rb.AddForce(direction * speed);
       //rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }

    public void MoveCreatureTransform(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime *speed;
    }
}
