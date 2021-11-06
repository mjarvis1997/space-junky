using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShip : MonoBehaviour
{
    private Animator animator;
    public GameObject projectile;
    public Transform AttackPoint;
    public Transform AttackPoint1;
    public Transform AttackPoint2;
    public Transform AttackPoint3;
    public Transform AttackPoint4;

    private float timeBtwShots;
    public float startTimeBtwShots;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            animator.Play("Base Layer.pirateShipCannons");
            Instantiate(projectile, AttackPoint.position, Quaternion.AngleAxis(45, Vector3.up));
            Instantiate(projectile, AttackPoint1.position, Quaternion.identity);
            Instantiate(projectile, AttackPoint2.position, Quaternion.identity);
            Instantiate(projectile, AttackPoint3.position, Quaternion.identity);
            Instantiate(projectile, AttackPoint4.position, Quaternion.identity);
            
            timeBtwShots = startTimeBtwShots;

            animator.Play("Base Layer.idle");
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        
    }
}