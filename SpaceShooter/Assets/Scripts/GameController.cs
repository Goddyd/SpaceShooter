using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject[] hazard;
    public Vector3 spawnValue;
    public Text scoreText;
    public int hazardCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;
    private int scoreValue;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnWaves());
        scoreValue = 0;
        UpdateScore();
    }
	
	// Update is called once per frame
    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject gameObject = hazard[Random.Range(0, hazard.Length)];
                Vector3 spawnposition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x),
                spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(gameObject, spawnposition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
        
    }

    public void UpdateScore(int score = 0) {
        scoreValue = scoreValue + score;
        scoreText.text = scoreValue.ToString();
    }
}
