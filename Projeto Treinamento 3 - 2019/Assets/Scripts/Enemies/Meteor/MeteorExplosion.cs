using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorExplosion : MonoBehaviour
{
    [SerializeField] private int nFragments = 10;
    [SerializeField] private GameObject fragment;
    private int gamb = 0;


    void OnEnable()
    {
        gamb++;
    }

    void OnDestroy()
    {
        if (gamb > 1)
            Explosion();
        //problem:
        //Some objects were not cleaned up when closing the scene. (Did you spawn new GameObjects from OnDestroy?)
        //Explosion();
    }

    public void Explosion()
    {
        if(nFragments == 1) {
            Instantiate(fragment, transform.position, Quaternion.Euler(0, 0, 0));
        } else {
            float angleVariation = 120 / (nFragments - 1);
            for (int i = 0; i < nFragments; i++) {
                Instantiate(fragment, transform.position, Quaternion.Euler(0, 0, (angleVariation * i) - 60));
            }
        }

        //Destroy(gameObject);
    }
}
