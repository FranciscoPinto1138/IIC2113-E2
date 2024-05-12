namespace Fire_Emblem;

public class NeutralizeBonusOnStats : Effect
{
    private List< StatType> _statsToNeutralize;
    
    public NeutralizeBonusOnStats(List< StatType> statsToNeutralize)
    {
        _statsToNeutralize = statsToNeutralize;
        this.SetPriority(1);
    }

    public override void ApplyEffect(Unit unit, Unit opponent)
    {
        foreach (var stat in _statsToNeutralize)
        {
            switch (stat)
            {
                case StatType.Atk:
                    unit.BonusNeutralizationManager.Atk = 0;
                    break;
                case StatType.Spd:
                    unit.BonusNeutralizationManager.Spd = 0;
                    break;
                case StatType.Def:
                    unit.BonusNeutralizationManager.Def = 0;
                    break;
                case StatType.Res:
                    unit.BonusNeutralizationManager.Res = 0;
                    break;
                case StatType.HP:
                    unit.BonusNeutralizationManager.HP = 0;
                    break;
            }
        }
    }
}