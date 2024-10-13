using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // private 不可以在uinty中調整，public 可以，無宣告時預設為private
    // public float moveSpeed = 5f;
    // 以下是保留private屬性又可以在uinty中調整
    [SerializeField] float moveSpeed = 5f;
    GameObject currentFloor;
    [SerializeField] int HP;
    [SerializeField] GameObject HpBar;
    Animator anim;
    SpriteRenderer render;
    [SerializeField] GameObject replayButton;
    // Start is called before the first frame update
    void Start()
    {   // 物件移動方法
       
        HP=10;
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(moveSpeed*Time.deltaTime,0,0);
            render.flipX=false;
            anim.SetBool("run",true);
        }
        else if(Input.GetKey(KeyCode.A)){
            transform.Translate(-moveSpeed*Time.deltaTime,0,0);
            render.flipX=true;
            anim.SetBool("run",true);
        }
        else{
            anim.SetBool("run",false);
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Normal"){

            if(other.contacts[0].normal == new Vector2(0f,1f)){
                Debug.Log("撞到Normal");
                currentFloor = other.gameObject;
                ModifyHP(1);
            }
           
        }
        else if(other.gameObject.tag == "Nails"){

            if(other.contacts[0].normal == new Vector2(0f,1f)){
                 Debug.Log("撞到Nails");
                currentFloor = other.gameObject;
                ModifyHP(-3);
                anim.SetTrigger("hurt");
            }
            
        }  
        else if(other.gameObject.tag == "Ceiling"){
           
            Debug.Log("撞到Ceiling");
            currentFloor.GetComponent<BoxCollider2D>().enabled = false;
            ModifyHP(-3);
            anim.SetTrigger("hurt");
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "DeathLine"){
                Debug.Log("你輸了");
                Die();
            }
        }
    void ModifyHP(int num){
        HP += num;

        if(HP > 10){
            HP = 10;
        }
        else if(HP < 0){
            HP = 0;
            Die();
        }
        UpdateHPBar();
    }
    void UpdateHPBar(){
        for(int i=0; i<HpBar.transform.childCount;i++){

            if(HP>i){
                HpBar.transform.GetChild(i).gameObject.SetActive(true);
            }
            else{
                HpBar.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    void Die(){
        Time.timeScale = 0f;
        replayButton.SetActive(true);
    }

    public void Replay(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
        
}
