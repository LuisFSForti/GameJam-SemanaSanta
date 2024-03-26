using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJogador : MonoBehaviour
{
    //https://www.youtube.com/watch?v=5Rq8A4H6Nzw

    [SerializeField] private Transform Jogador;
    public float Sensibilidade = 2f;
    float RotacaoVertical = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad == 0)
            return;

        float inputX = Input.GetAxis("Mouse X") * Sensibilidade;
        float inputY = Input.GetAxis("Mouse Y") * Sensibilidade;

        RotacaoVertical -= inputY;
        RotacaoVertical = Mathf.Clamp(RotacaoVertical, -90f, 90f);
        transform.localEulerAngles = Vector3.right * RotacaoVertical;

        Jogador.Rotate(Vector3.up * inputX);
    }
}
