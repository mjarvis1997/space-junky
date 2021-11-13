using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCannonBall : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public int damageStrength;
    public int directionX;
    public int directionY;

    public GameObject hitExplosion;

    void Update()
    {
        rb.AddForce(new Vector2(speed * directionX, speed * directionY));
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = Utilities.findNonGenericParent(hitInfo.gameObject).GetComponent<Player>();

        if (player != null)
        {
            // Damage player
            Destroy(this.gameObject);
            Instantiate(hitExplosion, transform.position, transform.rotation);
        }
        else
        {
            //Debug.Log(hitInfo);
        }
    }
}
