using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update

    CommonSpaceship spaceship;

    public int hp = 5;

    IEnumerator Start()
    {
        spaceship = GetComponent<CommonSpaceship>();

        spaceship.Move(transform.up * -1);

        while(true)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                Transform shotPosition = transform.GetChild(i);

                spaceship.Shot(shotPosition);
            }

            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "PlayerBullet")
        {
            Transform playerBulletTransform = c.transform.parent;

            BulletBehaviour bullet = playerBulletTransform.GetComponent<BulletBehaviour>();

            hp = hp - bullet.power;

            Destroy(c.gameObject);

            if(hp <= 0)
            {
                spaceship.Explosion();

                Destroy(gameObject);
            }
        }
    }

}
