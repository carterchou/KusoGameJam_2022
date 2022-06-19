using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeToSpawn;
    private float timer;

    public Transform xMin, xMax, yMin, yMax;
    public GameObject[] enemys;
    public Transform enemyPos;

    private void Update() {
        timer -= Time.deltaTime;
        if (timer < 0f) SpawnEnemy();
    }

    private void SpawnEnemy() {
        GameObject enemy = Instantiate(enemys[Random.Range(0, enemys.Length)], GetBoundary(Random.Range(0, 4)), enemyPos.rotation);
        enemy.GetComponent<Enemy>().target = GameObject.Find("Player");
        timer = timeToSpawn;
        //Debug.Log($"<color=yellow>¡i¥Í©Ç¡j</color> ¥Í©ÇX½d³ò¡G{xMin.transform.position.x} ~ {xMax.transform.position.x}  " +
        //    $"¥Í©ÇY½d³ò¡G{yMin.transform.position.y} ~ {yMax.transform.position.y}");
    }

    private Vector2 GetBoundary(int key) {
        switch (key) {
            case 0:
                return new Vector2(Random.Range(xMin.transform.position.x, xMax.transform.position.x), yMax.transform.position.y);
            case 1:
                return new Vector2(Random.Range(xMin.transform.position.x, xMax.transform.position.x), yMin.transform.position.y);
            case 2:
                return new Vector2(xMax.transform.position.x, Random.Range(yMin.transform.position.y, yMax.transform.position.y));
            case 3:
                return new Vector2(xMin.transform.position.x, Random.Range(yMin.transform.position.y, yMax.transform.position.y));
        }
        return new Vector2(Random.Range(xMin.transform.position.x, xMax.transform.position.x), yMax.transform.position.y);
    }
}
