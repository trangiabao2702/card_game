using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private MainCharacter mainCharacter;
    private int playerRank;
    const float MinX = 5f;
    const float MinY = -2.5f;
    const float MaxX = 50f;
    const float MaxY = 4f;

    private int mobCount = 0;

    [SerializeField] GameObject BlackRankEnemy;
    [SerializeField] GameObject YellowRankEnemy;
    [SerializeField] GameObject RedRankEnemy;
    [SerializeField] GameObject WhiteRankEnemy;
    void Start()
    {
        playerRank = mainCharacter.getPlayerRank();
    }

    // Update is called once per frame
    void Update()
    {

        if (mobCount < 4) {
            mobCount+=4;
            spanMob(WhiteRankEnemy);
            spanMob(BlackRankEnemy);
            spanMob(RedRankEnemy);
            spanMob(YellowRankEnemy);
        }
    }

    void spanMob(GameObject mobtype)
    {
        GameObject newEnemy = Instantiate(mobtype, new Vector3(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY), -0.1f), Quaternion.identity);
    }

    public void decreaseMobCount()
    {
        mobCount--;
    }
}
