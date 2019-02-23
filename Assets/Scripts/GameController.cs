using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public float startWait;
    public float waveWait;
    public float spawnWait;
    public int hazardCount;
    public GUIText scoreText;
    private int score;
    private void Start()
    {
        score = 0;
        ScoreUpdate();
        StartCoroutine (SpawnHazard());
    }
    private IEnumerator SpawnHazard()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i=0;i<hazardCount;i++)
            {
                Vector3 spawnPosition =new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    public void AddScore (int newScore)
    {
        score += newScore;
        ScoreUpdate();
    }
    void ScoreUpdate ()
    {
        scoreText.text = "Score: " + score; 
    }

}
