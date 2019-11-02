using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    /// <summary>background offset speed</summary>
	[SerializeField] private float speed = 3;

    /// <summary>renderer obj 3D</summary>
    [SerializeField] private Renderer Img = null;

    void Update()
    {
        Offset();
    }

    private void Offset()
    {
        Vector2 offset = new Vector2(speed * Time.deltaTime, 0);
        Img.material.mainTextureOffset += offset;//translates the texture of the material according to the offset vector
    }
}
