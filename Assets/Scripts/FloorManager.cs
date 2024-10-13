using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class FloorManager : MonoBehaviour
{
    [SerializeField] GameObject[] floorPrefabs;
    [SerializeField] TextMeshProUGUI scoreText;
    int score;
  public void SpawnFloor () {
    score=0;
    //從地板物件中，隨機選取
    int r = Random.Range(0,floorPrefabs.Length);
    //生成物件
    GameObject floor = Instantiate(floorPrefabs[r],transform);
    //生成位置
    floor.transform.position = new Vector3(Random.Range(-4.2f,2.5f),-2f,0f);
    UpdateScore();
  }
  void UpdateScore(){
    score++;
    scoreText.text = "Layer "+ score;
  }
}
