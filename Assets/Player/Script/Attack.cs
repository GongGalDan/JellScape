using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public enum Type { Melee, Buff, Special};
    public Type type;
    public int damage;
    public float rate;
    public BoxCollider meleeArea;
    public CapsuleCollider SpecialArea;
    public TrailRenderer trailEffect;

    public void Use()
    {
        if(type== Type.Melee)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
    }

    IEnumerator Swing()
    {
        yield return new WaitForSeconds(0.1f);
        meleeArea.enabled = true;
        trailEffect.enabled = true;

        yield return new WaitForSeconds(0.2f);
        meleeArea.enabled = false;

        yield return new WaitForSeconds(0.3f);
        trailEffect.enabled = false;

    }



}
