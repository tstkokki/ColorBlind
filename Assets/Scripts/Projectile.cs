using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float force = 100;
    public ParticleSystem splat;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] LayerMask effectLayer;
    [SerializeField] ColorData_SO colorData;
    [SerializeField] SpriteRenderer renderer;
    ColorSpectrum.ColorSpec _mySpec;
    // Start is called before the first frame update
    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();

        _mySpec = colorData.colorData.currentSpec;
        rb.AddForce(transform.right * force, ForceMode.Impulse);
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = colorData.colorData.GetColor(colorData.colorData.currentSpec);
        Destroy(gameObject, 5f);

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player"))
        {
            var _ground = collision.gameObject.GetComponent<GroundSplatGenerator>();
            if (_ground != null) _ground.GenerateSplat(transform.position);

            ParticleSystem pat = Instantiate(splat, transform.position, transform.rotation);
            var main = pat.main;
            main.startColor = renderer.color;
            ColorBehaviour _other = collision.gameObject.GetComponent<ColorBehaviour>();
            if (_other != null) _other.ChangeColor(_mySpec);

            Destroy(gameObject);
        }
    }
}
