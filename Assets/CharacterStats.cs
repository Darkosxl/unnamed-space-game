using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    // Start is called before the first frame update

    public float type;
    private float HP;
    private float MP;
    private float nitro;

    private bool hpregen = false;
    private bool mpregen = false;
    private bool nitroregen = false;

    public float maxMP;
    public float maxHP;
    public float maxNitro;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    public healthbar hpbar;
    public healthbar nitrobar;
    public healthbar manabar;
   
    void Start()
    {
        if (type < 2)
        {
            hpbar.setMaxHealth(maxHP);
            nitrobar.setMaxHealth(maxNitro);
            manabar.setMaxHealth(maxMP);
        }
        HP = maxHP;
        MP = maxMP;
        nitro = maxNitro;
        Debug.Log("The HP is: " + maxHP);
    }

    public void takeDamage(float damage)
    {
        HP -= damage;
        Debug.Log("The HP remaining: " + HP);
        if (type <2)
        {
            hpbar.setHealth(HP);
            if (!hpregen)
            StartCoroutine(regenBar(1));
        }
        if (HP <= 0)
        {
           Destroy(gameObject);
        }
    }
    public void hitNitro(float usedgas)
    {
        
        if (type < 2)
        {
            nitro -= usedgas;
            nitrobar.setHealth(nitro);
        }
            if (!mpregen && type < 2)
        StartCoroutine(regenBar(3));

    }
    public void useAmmo(float ammo)
    {


        if (type < 2)
        {
            MP -= ammo;
            manabar.setHealth(MP);

        }
        if(!nitroregen && type < 2)
        StartCoroutine(regenBar(2));
    }
    public float getNitro()
    {
        return nitro;
    }
    public float getAmmo()
    {
        return MP;
    }
    private IEnumerator regenBar(int hmn)
    {
        //1 for HP 2 for MP 3 for Nitro
        yield return new WaitForSeconds(2f);
        if (hmn == 2)
        {
            while (MP < maxMP)
            {
                mpregen = true;
                MP += maxMP / 100;
                manabar.setHealth(MP);
                yield return regenTick;
            }
            mpregen = false;
            yield break;
        }
        if(hmn == 1)
        {
            while(HP < maxHP)
            {
                hpregen = true;
                HP += maxHP / 200;
                hpbar.setHealth(HP);
                yield return regenTick;
            }
            hpregen = false;
            yield break; 
        }
        if(hmn == 3)
        {
            while(nitro < maxNitro)
            {
                nitroregen = true;
                nitro += maxNitro / 200;
                nitrobar.setHealth(nitro);
                yield return regenTick;
            }
            nitroregen = false;
            yield break;
        }

    }
    // Update is called once per frame
    void Update()
    {
       // HP += 0.1f;
       // nitro += 0.5f;
       // MP += 0.1f;

      //  hpbar.setHealth(HP);
       // nitrobar.setHealth(nitro);
       // manabar.setHealth(MP);
    }
}
