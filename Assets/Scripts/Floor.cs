using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floor : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          transform.Translate(0,moveSpeed*Time.deltaTime,0);
          //超過畫面刪除地板物件，並重新生成地板物件
          if(transform.position.y > 5f){
            //刪除物件
            Destroy(gameObject);
            //呼叫父物件方法
            transform.parent.GetComponent<FloorManager>().SpawnFloor();
          }

    }
}
