using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterShooter : MonoBehaviour
{
    public GameObject shot = null;
    public float openingAngle = 30f;
    public int numberOfShots = 5;
    public bool randomScatter = false;

    public float timeBetweenShots = 0.3f;
    private float shootingTimer = 0f;

    public Vector3 offset = new Vector3(0,0,0);

    // Update is called once per frame
    void Update(){
        shootingTimer -= Time.deltaTime;
    }

    void Shoot(){
        if (shootingTimer <= 0){
            shootingTimer = timeBetweenShots;
            InstantiateShot();
            SoundManager.PlaySound("scatterShot");
        }
    }

    void InstantiateShot(){
        float[] angles = new float[numberOfShots];
        if (randomScatter){
            for (int i = 0; i < numberOfShots; i++){
                angles[i] = Random.Range(-openingAngle/2,openingAngle/2);
            }
        }else{
            for (int i = 0; i < numberOfShots; i++){
                angles[i] = -openingAngle/2 + (float)i * openingAngle/((float)(numberOfShots-1));
            }
        }
        foreach (float a in angles){
            Vector3 pos = transform.position + offset;
            Quaternion dir = transform.rotation * Quaternion.Euler(0, 0, a);
            GameObject s = Instantiate(shot, pos, dir);
            s.SendMessage("SetOwner",transform.parent.gameObject);
        }
    }
}
