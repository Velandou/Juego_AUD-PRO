using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform Player;

    private float tamañoCam;
    private float alturaPantalla;
    // Start is called before the first frame update
    void Start()
    {
        tamañoCam = Camera.main.orthographicSize;
        alturaPantalla = tamañoCam * 2;
    }

    // Update is called once per frame
    void Update()
    {
        CalcPosCam();
    }

    void CalcPosCam()
    {
        int pantallaPlayer = (int)(Player.position.y / alturaPantalla);
        float alturaCamara = (pantallaPlayer * alturaPantalla) + tamañoCam;

        transform.position = new Vector3(transform.position.x, alturaCamara, transform.position.z);
    }
}
