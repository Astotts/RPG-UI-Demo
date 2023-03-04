using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    [SerializeField] Transform initialPosition;
    [SerializeField] Transform attackPosition;

    [SerializeField] int maxHealth, curHealth;
    [SerializeField] int damage;
    //[SerializeField] SpriteRenderer[] effects;

    [SerializeField] HealthUI healthBar;
    [SerializeField] Animator attackAnim;

    private float elapsed;
    private float duration = 3f;
    private float percent;

    private Vector3 desiredPos;
    private Vector3 initialPos;

    private Character target;

    //Enemy only variables
    [SerializeField] SpriteRenderer enemyRenderer;
    [SerializeField] Sprite[] enemyImages;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = initialPosition.position;
        desiredPos = initialPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        Mathf.Clamp(0, duration, elapsed);
        percent = elapsed / duration;
        this.transform.position = Vector3.Lerp(initialPos, desiredPos, elapsed);
        if(this.transform.position == desiredPos){
            if(desiredPos == attackPosition.position){
                desiredPos = initialPosition.position;
                initialPos = attackPosition.position;
                elapsed = 0f;
            }
            weapon.SetActive(false);
        }
        if(this.curHealth <= 0f){
            this.Kill();
            this.curHealth = maxHealth;
            healthBar.UpdateHealth(maxHealth, maxHealth);
        }
    }

    public void Attack(Character target){
        elapsed = 0f;
        weapon.SetActive(true);
        desiredPos = attackPosition.position;
        initialPos = initialPosition.position;
        attackAnim.Play("KatanaSwing", 0, 0.0f);
        target.curHealth -= damage;
        target.healthBar.UpdateHealth(target.curHealth, target.maxHealth);
    }

    public void Effect(Sprite sprite){
        //Set next effect
    }

    //Just a cheesy way to make it appear like they're fighting multiple monsters
    public void Kill(){
        enemyRenderer.sprite = enemyImages[Random.Range(0,10)];
    }
}
