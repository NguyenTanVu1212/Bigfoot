using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    protected Vector3 dir;
    protected TypeBullet typeBullet;
    protected float speed;
    protected float damage;
    protected float cirt;
    protected float timeEffect;
    protected float rateEffect;
    public BulletDataBinding dataBinding;
    
    private void Awake()
    {
        GetComponent<Rigidbody2D>();
        if(dataBinding== null)
        {
            GetComponent<BulletDataBinding>();
        }
    }
    private void Start()
    {
        //this.dir = Vector3.right;
        //this.speed = 2f;
        //this.typeBullet = TypeBullet.Burning;
    }
    void Update()
    {
        OnUpdate();
        transform.Translate(dir*Time.fixedDeltaTime*speed);
        if (Mathf.Abs(transform.position.x) > 10)
        {
            transform.gameObject.SetActive(false);
        }
    }
    public virtual void OnUpdate()
    {

    }
    public virtual void OnSetup()
    {

    }
    public void Setup(Vector3 dir, float speed, float damage, float crit,TypeBullet typeBullet , float _timeEffect , float _rateEffect)
    {
        this.dir = dir;
        this.speed = speed;
        this.damage = damage;
        this.typeBullet = typeBullet;
        this.cirt = crit;
        this.timeEffect = _timeEffect;
        this.rateEffect = _rateEffect;
        OnSetup();
    }
    private void FixedUpdate()
    {
        OnFixUpdate();
    }
    public virtual void OnFixUpdate()
    {

    }
    protected void HitBullet(Collider2D collision)
    {
        OnHitBullet(collision);
    }
    public virtual void OnHitBullet(Collider2D collision)
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitBullet(collision);
    }
    public void DestroyBullet()
    {
        gameObject.SetActive(false);
    }
}
public enum TypeBullet
{
    Normal =0 ,
    Burning = 1,
    Freeze =2 
}
