using UnityEngine;

public class Fighter : MonoBehaviour
{
    // Public Fields
    public int hitPoints = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    // Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    // Push
    protected Vector3 pushDirection;

    protected virtual void RecieveDamage(Damage dmg) 
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitPoints -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 20, Color.red, transform.position, Vector3.down * 30, 0.5f);

            if (hitPoints <= 0)
            {
                hitPoints = 0;
                Death();
            }
        }
    }
    
    public void AddHealth(int health)
    {
        if (hitPoints == maxHitpoint)
            return;

        int hitPointMissing = maxHitpoint - hitPoints;
        if (hitPointMissing < health)
            hitPoints = maxHitpoint;
        else
        hitPoints += health;
        GameManager.instance.OnHitPointChange();
    }
    

    protected virtual void Death()
    {

    }

}
