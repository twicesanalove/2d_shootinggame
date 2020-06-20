﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    CommonSpaceship spaceship;

    IEnumerator Start()
    {
        spaceship = GetComponent<CommonSpaceship>();

        while (true)
        {
            //spaceship.Shot(transform);

            yield return new WaitForSeconds(spaceship.shotDelay);
        }

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        spaceship.Move(direction);

        Clamp();
    }

    void Clamp()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);

        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "Enemy")
        {
            Destroy(c.gameObject);

            spaceship.Explosion();

            Destroy(gameObject);

            FindObjectOfType<Manager>().GameOver();
        }
    }

}