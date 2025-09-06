using System.Runtime.InteropServices;
using UnityEngine;

public class CodigonaveC : MonoBehaviour
{
    private Animator anim;
    private CharacterController _naveC;
    private float _velocidadMovimiento;
    private Vector3 _moverEjes;
    private Vector3 _puedoAvanzar,_esCorrecto,_moverme;
    private Camera _camara;

    [SerializeField] private float _Gravedad;
    [SerializeField] private float _caida;
    [SerializeField] private float _fuerzaSalto;

 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        _velocidadMovimiento = 50f;
        _naveC = GetComponent<CharacterController>();
        _camara = Camera.main;
        _Gravedad = 60f;
        _fuerzaSalto = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        _moverEjes = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        anim.SetFloat("PosX",_moverEjes.x);
        anim.SetFloat("PosZ",_moverEjes.z);
        if (_moverEjes.magnitude > 1) _moverEjes = _moverEjes.normalized * _velocidadMovimiento;
        else _moverEjes = _moverEjes * _velocidadMovimiento;

        camaraDireccion();
        _moverme = _moverEjes.x * _esCorrecto + _moverEjes.z *_puedoAvanzar;
        transform.LookAt(transform.position + _moverme);
        setGravity();
        setSaltar();
        _naveC.Move(_moverme * Time.deltaTime);
    }
    private void camaraDireccion() 
    {
        _puedoAvanzar = _camara.transform.forward.normalized;
        _esCorrecto = _camara.transform.right.normalized;
        _puedoAvanzar.y = 0;
        _esCorrecto.y = 0;
    }
    private void setGravity() 
    {
      if(_naveC.isGrounded) 
        {
            anim.SetFloat("Saltar", 0);
            _caida = - _Gravedad *Time.deltaTime;
        }
        else 
        {
            anim.SetFloat("Saltar", 1);
            _caida -= _Gravedad *Time.deltaTime;
        }
      _moverme.y = _caida;
    }
    private void setSaltar() 
    {
      if(_naveC.isGrounded && Input.GetKey(KeyCode.Space)) 
        {
            _caida = _fuerzaSalto;
            _moverme.y = _caida;
        }
    }
}
