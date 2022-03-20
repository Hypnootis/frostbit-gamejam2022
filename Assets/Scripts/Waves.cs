using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{

    public int wave = 0;
    public bool waveEnd = false;
    public GameObject boss;
    public GameObject player;
    private GameObject playerWeapon;
    private Sprite bossSprite;
    public Sprite[] bossSprites;
    public GameObject[] weapons;
    public GameObject[] bossWeapons;
    public int oldWave;
    // Start is called before the first frame update
    void Start()
    {
        bossSprite = boss.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (oldWave != wave)
        {
            waveRules();
            oldWave = wave;
        }
    }


    public void changeSprite(SpriteRenderer sprite, int index) {
        sprite.sprite = this.bossSprites[index];
    }

    public void changeWave(int newWave)
    {
        this.wave = newWave;
        Debug.Log(wave);
    }

    public string waveRules()
    {
        string waveDesc = "";
        if (wave >= 0 && wave <= 2)
        {
            player.GetComponent<Shoot>().changeProjectile(null);
            boss.GetComponent<shootingPatterns>().changeWeapon(bossWeapons[0]);
            waveDesc = "early";
        }
        if (wave >= 3 && wave <= 4)
        {
            player.GetComponent<Shoot>().changeProjectile(weapons[1]);
            boss.GetComponent<shootingPatterns>().changeWeapon(bossWeapons[1]);
            waveDesc = "mid";
        }

        if (wave >= 5)
        {
            boss.GetComponent<shootingPatterns>().changeWeapon(bossWeapons[3]);
            waveDesc = "late";
        }
        return waveDesc;

    }

}
