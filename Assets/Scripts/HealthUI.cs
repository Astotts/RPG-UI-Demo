using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    //HealthGUI
    [SerializeField] private Transform bar;

    private float size = 1f;

    // Start is called before the first frame update
    void Start()
    {
        SetSize(size);
    }

    public void SetSize(float sizeNormalized){
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
    
    public void UpdateHealth(float health, float maxHealth){
        if(health > 0){
            size = (health / maxHealth);
            SetSize(size);
        }
        else{
            size = 0f;
            SetSize(size);
        }
    }
}
