using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] monsterReference;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedMonster;
    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(SpawnMonsters());
    }

    // spwaning monsters randomly
    IEnumerator SpawnMonsters() {
        
        while (true) {
            yield return new WaitForSeconds(Random.Range(1, 5));

            // getting a random number in thr array of monsters
            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            // spawning the monster
            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            transform.position = new Vector3(transform.position.x, transform.position.y, 70);

            // left side
            if (randomSide == 0) {
                spawnedMonster.transform.position = leftPos.position;

                // accessing the class to assign the monster speed randomly
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);

            }
            // right side
            else {
                spawnedMonster.transform.position = rightPos.position;

                // accessing the class to assign the monster speed randomly
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
    
}
