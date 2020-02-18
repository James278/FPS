using System;
using UnityEngine;

public class HealthScript_FPS : MonoBehaviour
{
    /* This is just part of the tutorial and we don't need this.
    
    private EnemyAnimator enemy_Anim;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private EnemyController enemy_Controller;
    */

    public float health = 100f;
    public bool is_Player;
    public bool is_Boar;
    public bool is_Cannibal;

    private bool is_Dead;

    private void Awake()
    {
        if (is_Boar || is_Cannibal)
        {
            /*
            enemy_Anim = GetComponent<EnemyAnimator>();
            enemy_Controller = GetComponent<EnemyController>();
            navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            */

            // Get enemy audio
        }

        if (is_Player)
        {

        }
    }

    public void ApplyDamage(float damage)
    {
        // If we died don't execute the rest of the code et voilà.
        if (is_Dead) { return; }

        health -= damage;

        if (is_Player)
        {

        }


        // if (is_Boar || is_Cannibal)
        // {
        //     if (enemy_Controller.Enemy_State == EnemyState.PATROL)
        //     {
        //         enemy_Controller.chase_Distance = 50f;
        //     }
        // }


        // If health is less than or equal to 0f, call die/lose logic.
        if (health <= 0f)
        {
            PlayerDead();
            is_Dead = true;
        }
    }

    private void PlayerDead()
    {

        //     if (is_Cannibal)
        //     {
        //         GetComponent<Animator>().enabled = false;
        //         GetComponent<BoxCollider>().enabled = false;
        //         GetComponent<Rigidbody>().AddTorque(-transform.forward * 50f);

        //         enemy_Controller.enabled = false;
        //         navMeshAgent.enabled = false;
        //         enemy_Anim.enabled = false;
        //     }

        //     if (is_Boar)
        //     {
        //         navMeshAgent.velocuty = Vector3.zero;
        //         navMeshAgent.isStopped = true;
        //         enemy_Controller.enabled = false;

        //         enemy_Anim.Dead();
        //     }

        if (is_Player)
        {
            // You should never do this!
            //GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);

            // for (int i = 0; i < enemies.Length; i++)
            // {
            //    enemies[i].GetComponent<EnemyController>().enabled = false;
            // }

            // Disable core functionalities of the player et voilà.
            GetComponent<PlayerMovement_FPS>().enabled = false;
            GetComponent<PlayerAttack_FPS>().enabled = false;
            GetComponent<WeaponManager_FPS>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
        }
    
        // If the player died, restart the game after 3 seconds, else just turn off the gameobject et voilà
        if (tag == Tags.PLAYER_TAG)
        {
            Invoke("RestartGame", 3f);
        }
        else
        {
            Invoke("TurnOffGameObject", 3f);
        }
    }

    private void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    private void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }
}