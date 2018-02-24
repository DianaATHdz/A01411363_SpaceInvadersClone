using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //   This script takes a spritesheet to simulate a gif
    //   animation as the sprite of player and enemy
public class SpriteChanger : MonoBehaviour {
    public Texture2D spritePlayer;
    public Texture2D spriteEnemy;
    public Sprite[] framesPlayer;
    public GameObject player;
    public int playerFPS;
    public int enemyFPS;
    public Sprite[] framesEnemy;
    public bool enablePlayer, enableEnemy;
    private bool PlayerTrigger, EnemyTrigger;
    // Use this for initialization
    void Start () {
        EnemyTrigger = PlayerTrigger = false;
        framesPlayer = Resources.LoadAll<Sprite>(spritePlayer.name);
        framesEnemy = Resources.LoadAll<Sprite>(spriteEnemy.name);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float indexPlayer = (Time.time * playerFPS) % framesPlayer.Length;
        float indexEnemy = (Time.time * enemyFPS) % framesEnemy.Length;
        if (enablePlayer)
        {
            if (player)
            {
                player.GetComponent<SpriteRenderer>().sprite = framesPlayer[(int)indexPlayer];
            }
            if (!PlayerTrigger)
            {
                Destroy(player.GetComponent<PolygonCollider2D>());
                player.AddComponent<PolygonCollider2D>();
                player.GetComponent<PolygonCollider2D>().isTrigger = true;
                PlayerTrigger = true;
            }
        }
        if (enableEnemy)
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<SpriteRenderer>().sprite = framesEnemy[(int)indexEnemy];
                if (!EnemyTrigger)
                {
                    Destroy(player.GetComponent<PolygonCollider2D>());
                    enemy.AddComponent<PolygonCollider2D>();
                    enemy.GetComponent<PolygonCollider2D>().isTrigger = true;
                    EnemyTrigger = true;
                }
            }
        }
    }
}
