using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BossMovement : MonoBehaviour
{
    Animator anim;
    Rigidbody rig;
    public GameObject player;
    bool isWalking;
    bool isAttacking;
    public NavMeshAgent agent;
    public float updateTime = 0;
    bool getHurtStats = false;
    public GameObject Instantiate_Position;
    public GameObject Box;
    public HealthBar bar;
    EnemiesData enemdata;
   
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        enemdata = GetComponent<EnemiesData>();
        isWalking = false;
        isAttacking = false;
        bar.SetMaxHealth(100);
        bar.SetHealth(100);



    }




    public bool GetHurt()
    {
        return getHurtStats;
    }

    public void SetHurtStats(bool getHurtStats)
    {
        this.getHurtStats = getHurtStats;
    }

    public void SetHealth(int damge)
    {
        bar.SetHealth(enemdata.GetHealth() - damge);
    }


    // Update is called once per frame
    void Update()
    {
        int randomTimer = Random.Range(0, 500);
        updateTime += Time.deltaTime;
        float dist = Vector3.Distance(this.transform.position, player.transform.position);

        for (int i = 0; i < 500; i++) { 
            if (i == randomTimer)
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
                isAttacking = true;
                isWalking = false;


                randomTimer = 0;
            }
            else
            {
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWalking", true);
                isAttacking = false;
                isWalking = true;
            }
        }



        if (isAttacking)
        {
           
            agent.destination = this.transform.position;
            for (int j = 0; j < 3; j++)
            {
                StartCoroutine(WaitForSpawn());
            }
        }

        if(getHurtStats == true)
        {
            anim.SetTrigger("idle");
        }


    }


    void SpawnLightingBall()
    {
        GameObject instantiateObject = Instantiate(Box, Instantiate_Position.transform.position, Instantiate_Position.transform.rotation);

    }


    IEnumerator WaitForSpawn()
    {
        yield return new WaitForSeconds(2);
        SpawnLightingBall();
    }


    private void LateUpdate()
    {
 
        if (updateTime > 2)
        {
            agent.destination = player.transform.position;
            updateTime = 0;
        }
    }




}
