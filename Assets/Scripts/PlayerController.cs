using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 100f)]
    public float Energy = 100.0f;
    public float MaxEnergy = 100.0f;
    public float Speed = 10.0f;
    public float FireRate = 1.0f;
    public float EnemyHitDamage = 10.0f;

    public float Fuel = 0.0f;
    public float MaxFuel = 100.0f;

    public enum PlayerState { Alive, Dead }
    public PlayerState State = PlayerState.Alive;
    public GameObject PlayerSprite;
    public bool InRangeOfGenerator;
    public float MinDistanceToGenerator = 3f;
    public float delayInvulnarable = 1f;
    public AudioClip ShootSound;
    public AudioClip PowerupSound;
    public AudioClip HurtSound;
    private float timeStampDelayShooting = 0f;

    private float timeStampInvulnarable = 0f;
    private Rigidbody2D rigidBody;
    private bool coroutineCalled = false;
    private bool isDead = false;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (State)
        {
            case PlayerState.Alive:
                RotateSprite();
                Shoot();
                CheckHealth();
                CheckInvulnarable();
                CheckIfInRangeOfGenerator();
                ApplyFuelToGenerator();
                break;
            case PlayerState.Dead:
                KillPlayer();
                break;
            default:
                break;
        }

    }
    void FixedUpdate()
    {
        switch (State)
        {
            case PlayerState.Alive:
                MovePlayer();
                break;
            default: break;
        }
    }
    private GameObject nearestGenerator = null;
    private void CheckIfInRangeOfGenerator()
    {
        nearestGenerator = FindNearestGenerator();

        if (nearestGenerator == null)
        {
            InRangeOfGenerator = false;
            return;
        }
        float distance = Vector2.Distance(transform.position, nearestGenerator.transform.position);

        if (distance > MinDistanceToGenerator)
        {
            InRangeOfGenerator = false;
            return;
        }
        if (Fuel > 0)
        {
            InRangeOfGenerator = true;
            return;
        }

        InRangeOfGenerator = false;

    }
    private void MovePlayer()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rigidBody.AddForce(direction.normalized * Speed * Time.deltaTime);
    }

    private void Shoot()
    {
        float cost = gameObject.GetComponent<ShootScript>().Shoot(PlayerSprite.transform.rotation.eulerAngles.z);
        Energy -= cost;
    }
    private void ApplyFuelToGenerator()
    {
        if (Input.GetButtonDown("Use") && InRangeOfGenerator && (Fuel > 0))
        {
            Fuel -= 1;
            nearestGenerator.GetComponent<Fuel>().Add(1);
        }
    }
    private void CheckHealth()
    {
        if (Energy <= 0)
        {
            State = PlayerState.Dead;
        }
    }

    private void CheckInvulnarable()
    {
        if (Time.time < timeStampInvulnarable && !coroutineCalled)
        {
            StartCoroutine("FlashRedCourentine");
        }
    }

    IEnumerator FlashRedCourentine()
    {
        {
            while (Time.time < timeStampInvulnarable)
            {
                coroutineCalled = true;
                PlayerSprite.GetComponent<SpriteRenderer>().color = new Color(1, 0.9f, 0.9f, 1);
                yield return new WaitForSeconds(0.1f);
                PlayerSprite.GetComponent<SpriteRenderer>().color = new Color(1, 0.7f, 0.7f, 1);
                yield return new WaitForSeconds(0.1f);
                PlayerSprite.GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.5f, 1);
                yield return new WaitForSeconds(0.1f);
                PlayerSprite.GetComponent<SpriteRenderer>().color = new Color(1, 0.3f, 0.3f, 1);
                yield return new WaitForSeconds(0.1f);
                PlayerSprite.GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.5f, 1);
                yield return new WaitForSeconds(0.1f);
                PlayerSprite.GetComponent<SpriteRenderer>().color = new Color(1, 0.7f, 0.7f, 1);
                yield return new WaitForSeconds(0.1f);
                PlayerSprite.GetComponent<SpriteRenderer>().color = new Color(1, 0.9f, 0.9f, 1);
                yield return new WaitForSeconds(0.1f);
                PlayerSprite.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                yield return new WaitForSeconds(0.1f);
            }
            coroutineCalled = false;
        }
    }

    private void KillPlayer()
    {
        if (!isDead)
        {
            Sprite dead = Resources.Load<Sprite>("Sprites/MattDead");
            Debug.Log(dead);
            PlayerSprite.GetComponent<SpriteRenderer>().sprite = dead;
            isDead = true;
        }
    }

    private void RotateSprite()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(PlayerSprite.transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        PlayerSprite.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time >= timeStampInvulnarable && collision.gameObject.tag == Tag.Enemy)
        {
            AudioSource.PlayClipAtPoint(HurtSound, transform.position);
            Energy -= EnemyHitDamage;
            timeStampInvulnarable = Time.time + delayInvulnarable;
        }
    }

    private GameObject FindNearestGenerator()
    {
        return FindNearestObjectOfType(Tag.Generator);
    }
    private GameObject FindNearestObjectOfType(string type)
    {
        float minDist = Mathf.Infinity;

        Vector2 pos = gameObject.transform.position;

        GameObject generator = null;
        GameObject[] generators = GameObject.FindGameObjectsWithTag(type);

        foreach (var gen in generators)
        {
            float dist = Vector2.Distance(gen.transform.position, pos);

            if (dist < minDist)
            {
                minDist = dist;
                generator = gen;
            }
        }

        return generator;
    }

    public void ChangePowerUp(ShootScript.PowerUp PowerUpType)
    {
        AudioSource.PlayClipAtPoint(PowerupSound, transform.position);
        gameObject.GetComponent<ShootScript>().ChangePowerUp(PowerUpType);
    }
}
