using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPhase : MonoBehaviour
{
    public float speed;
    public Vector2 minimo;//x e y
    public Vector2 maximo;//x e y
    private Transform _transform;//muda o transform do obj
    private Vector3 _posicaoFinal;
    private Vector2 _lado = Vector2.one;//comeca da direita pra esquerda

    

    // Despertado é chamado quando a instância do script for carregada
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _posicaoFinal = _transform.position;
    }

    // Essa função será chamada a cada quadro da taxa de quadro fixada, se MonoBehaviour estiver habilitado
    private void FixedUpdate()
    {
        _posicaoFinal.x += speed * _lado.x;
        _posicaoFinal.y += speed * _lado.y;

        if (_posicaoFinal.y > maximo.y)//se passar ponto maximo
        {
            _lado.y = -1;
            _posicaoFinal.y += maximo.y - _posicaoFinal.y;
        }else
        if (_posicaoFinal.y < minimo.y)//se passar o ponto minimo
        {
            _lado.y = +1;
            _posicaoFinal.y += minimo.y - _posicaoFinal.y;
        }

        if (_posicaoFinal.x < minimo.x)
        {
            _lado.x = +1;
            _posicaoFinal.x += minimo.x - _posicaoFinal.x;
        }
        else if (_posicaoFinal.x > maximo.x)
        {
            _lado.x = -1;
            _posicaoFinal.x += maximo.x - _posicaoFinal.x;
        }

        _transform.position = _posicaoFinal;
    }

}
