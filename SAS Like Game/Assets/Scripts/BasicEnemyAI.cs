using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemyAI : MonoBehaviour
{

    [SerializeField] private GameObject enemySo;
    [SerializeField] public float curHealth;
    [SerializeField] Slider healthSlider;
    [SerializeField] GameObject healthBarUI;
    [SerializeField] GameObject effect;

    private GameObject player;
    private GameObject enemy;
    private Rigidbody rb;
    private float dist;
    private float enemySpeed = 10f;
    private Vector3 targetPosition;
    private int damageReceived;
    private MeshRenderer mRenderer;
    private Collider mCollider;

    private bool dead = false;
    private bool rewardGiven = false;

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject;
        rb = enemy.GetComponent<Rigidbody>();
        curHealth = 100;
        //healthSlider.value = CalculatePercentageOfHealth();
        mRenderer = GetComponent<MeshRenderer>();
        mCollider = GetComponent<Collider>();
        effect.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (dead == true && rewardGiven == false)
        {
            dead = false;
            //EventManager.OnEnemyDead(enemySo.value);
            rewardGiven = true;

        }
        AdquireTargets();
        dist = Vector3.Distance(enemy.transform.position, player.transform.position);
        healtUpdate();
    }

    void OnCollisionEnter(Collision bullet)
    {
        //if (bullet.gameObject.CompareTag("Bullet"))
        //{
        //    Debug.Log("He recibido daño");
        //    //damageReceived = bullet.gameObject.GetComponent<bulletDestroyer>().damage;
        //    //AddjustEnemyHealth(damageReceived);
        //}
    }

    private void AddjustEnemyHealth(int damageReceived)
    {
        curHealth -= damageReceived;
    }

    private void FixedUpdate()
    {
        MoveToTarget();
    }
    void AdquireTargets()
    {
        player = GameObject.FindGameObjectWithTag("Player");       
        targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, enemy.transform.position.z);
    }

    private void healtUpdate()
    {
        //healthSlider.value = CalculatePercentageOfHealth();

        //if (curHealth < enemySo.enemyHealth)
        //{
        //    healthBarUI.SetActive(true); 
        //}
        //if (curHealth <= 0)
        //{
        //    dead = true;
        //    DyingSequence();
        //}
        //if (curHealth > enemySo.enemyHealth)
        //{
        //    curHealth = enemySo.enemyHealth;
        //}
    }

    //private void DyingSequence()
    //{
        
    //    mRenderer.enabled = false;
    //    mCollider.enabled = false;
    //    rb.isKinematic = true;        
    //    effect.SetActive(true);
    //    Destroy(gameObject, 1f);
    //}

    //float CalculatePercentageOfHealth()
    //{
    //   return curHealth / enemySo.enemyHealth;
    //}

    private void MoveToTarget()
    {
        //if (dist > enemySo.closestDistance)
        //{
            
            enemy.transform.LookAt(player.transform.position);

            rb.AddForce(transform.forward.normalized * enemySpeed);

        //    //enemy.transform.Translate(Vector3.forward * Time.deltaTime * enemySpeed);
        //}
    }
}