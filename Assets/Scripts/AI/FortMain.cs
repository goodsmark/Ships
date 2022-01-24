using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class FortMain : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;
    [Space(5f)]
    [Header("Guns")]
    [SerializeField] protected Transform[] _gunsPositionFort;


    Slider _sliderHealth;
    Canvas _canvas;
    const int SLIDER_MIN_HEALTH = 0;


    protected void Start()
    {
        _sliderHealth = GetComponentInChildren<Slider>();
        _canvas = GetComponentInChildren<Canvas>();  
        health = maxHealth;
        _sliderHealth.value = health;
        _sliderHealth.maxValue = maxHealth;
        _sliderHealth.minValue = SLIDER_MIN_HEALTH;
        RecalculateRotationCanvas();
    }

    protected void OnCollisionEnter(Collision collision)
    {
        int damage;
        if (collision.gameObject)
        {
            collision.gameObject.GetComponent<ShipAmmunitions>().TakeDamage(out damage);
            health -= damage;
            collision.gameObject.SetActive(false);
            if (health <= 0)
            {
                health = 0;
                gameObject.SetActive(false);
            }
        }
    }
    private void Update()
    {
        RecalculateRotationCanvas();

        if (health < maxHealth)
        {
            _canvas.gameObject.SetActive(true);
        }
        else
            _canvas.gameObject.SetActive(false);


        _sliderHealth.value = health;
    }
    protected void RecalculateRotationCanvas()
    {
        var newRotation = Quaternion.LookRotation(PlayerMainController._instantiate._playerPoint.position - _canvas.transform.position, -Vector3.up);
        newRotation.z = 0.01f;
        newRotation.x = 0.01f;
        _canvas.transform.rotation = newRotation;
    }
}
