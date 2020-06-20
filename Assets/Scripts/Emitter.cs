using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] waves;

    private int currentWave;

    private Manager manager;

    IEnumerator Start()
    {
        if(waves.Length == 0)
        {
            yield break;
        }

        manager = FindObjectOfType<Manager>();

        while(true)
        {
            while(manager.IsPlaying() == false)
            {
                yield return new WaitForEndOfFrame();
            }

            GameObject wave = (GameObject)Instantiate(waves[currentWave], new Vector2(0.0f, 0.0f), Quaternion.identity);

            wave.transform.parent = transform;

            while(wave.transform.childCount !=0)
            {
                yield return new WaitForEndOfFrame();
            }

            Destroy(wave);

            if(waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
