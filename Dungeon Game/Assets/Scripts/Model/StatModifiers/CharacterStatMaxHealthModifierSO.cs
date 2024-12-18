using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChracterStatMaxHealthModifierSO : CharacterStatModifierSO
{
    public override void AffectCharacter(GameObject character, float val)
    {
            Fighter health = character.GetComponent<Fighter>();
        if (health != null )
        {
           health.AdjustMaxHeath((int)val);
           health.AddHealth((int)val);
        }
    }
}
