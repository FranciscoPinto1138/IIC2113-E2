namespace Fire_Emblem;

public class NeutralizeOpponentBonusStats : Effect
{
    private List< StatType> _statsToNeutralize;
    
    public NeutralizeOpponentBonusStats(List< StatType> statsToNeutralize)
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
                    opponent.BonusNeutralizationManager.Atk = 0;
                    break;
                case StatType.Spd:
                    opponent.BonusNeutralizationManager.Spd = 0;
                    break;
                case StatType.Def:
                    opponent.BonusNeutralizationManager.Def = 0;
                    break;
                case StatType.Res:
                    opponent.BonusNeutralizationManager.Res = 0;
                    break;
                case StatType.HP:
                    opponent.BonusNeutralizationManager.HP = 0;
                    break;
            }
        }
    }
}