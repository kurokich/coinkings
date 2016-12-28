using UnityEngine;
using System.Collections;

public class hitPlane : MonoBehaviour {
    public GameObject player;
    public GameObject enemy;
    public UILabel player_damage;
    public UILabel enemy_damage;

    private Animator enemy_damage_animate;
    private Animator player_damage_animate;

    void Awake()
    {
        //player_damage_animate = player_damage.GetComponent<Animator>();
        //enemy_damage_animate = enemy_damage.GetComponent<Animator>();
    }
    public void OnCollision()
    {
        if (enemy.GetComponent<GameManager>().mode == 1)
        {
            enemy.GetComponent<GameManager>().damage += 100;
            //enemy_damage_animate.SetTrigger("damage");
            enemy_damage.text = "-100";
        }
    }
    public void OnSideCollision()
    {
        if (player.GetComponent<GameManager>().mode == 0)
        {
            player.GetComponent<GameManager>().damage += 100;
            //player_damage_animate.SetTrigger("damage");
            player_damage.text = "-100";
        }
    }
}
