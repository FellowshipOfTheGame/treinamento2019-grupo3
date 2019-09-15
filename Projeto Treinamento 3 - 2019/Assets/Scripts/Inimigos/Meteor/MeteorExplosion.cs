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
        if(gamb >1)
            Explosion(nFragments);
    }

    void Explosion(int nFragments)
    {
        float angleVariation = 360 / nFragments;
        for (int i = 0; i < nFragments; i++)
        {
            Instantiate(fragment, transform.position, Quaternion.Euler(0, 0, angleVariation * i));
        }
    }
}
