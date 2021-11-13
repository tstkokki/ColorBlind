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
    [SerializeField] Sounds_SO _sounds;
    ColorSpectrum.ColorSpec _mySpec;
    // Start is called before the first frame update
    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();

        _mySpec = colorData.colorData.currentSpec;
        rb.AddForce(transform.right * force, ForceMode.Impulse);
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = colorData.colorData.GetColor(colorData.colorData.currentSpec);
        var main = transform.GetChild(0).GetComponent<ParticleSystem>().main;
        main.startColor = renderer.color;

        Destroy(gameObject, 5f);

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("Pickup"))
        {
            // splat dissolve
            var _ground = collision.gameObject.GetComponent<GroundSplatGenerator>();
            if (_ground != null)
            {
                _ground.GenerateSplat(transform.position);
            }
            //particle effect to spawn on impact
            ParticleSystem pat = Instantiate(splat, transform.position, transform.rotation);
            var main = pat.main;
            main.startColor = renderer.color;
            //set the color behaviour of the target
            ColorBehaviour _other = collision.gameObject.GetComponent<ColorBehaviour>();
            if (_other != null) _other.ChangeColor(_mySpec);
            _sounds.PlayFromList(0);
            Destroy(gameObject);
        }
    }
}
