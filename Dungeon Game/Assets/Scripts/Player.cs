using UnityEngine;

public class Player : Mover
{
    public float xSpeedPlayer = 0.75f;
    public float ySpeedPlayer = 0.75f;

    protected override void RecieveDamage(Damage dmg)
    {
        base.RecieveDamage(dmg);
        GameManager.instance.OnHitPointChange();
    }

    public void AdjustSpeed(int speed)
    {
        xSpeedPlayer = xSpeedPlayer * speed;
        ySpeedPlayer = ySpeedPlayer * speed;
    }

    private void FixedUpdate()
    {
        // Look for input on keyboard
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0), xSpeedPlayer, ySpeedPlayer);

    }

}
