namespace Fire_Emblem;

public class NeutralizeOpponentPenaltyStats : Effect
{
    private List< StatType> _statsToNeutralize;
    
    public NeutralizeOpponentPenaltyStats(List< StatType> statsToNeutralize)
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
                    opponent.PenaltyNeutralizationManager.Atk = 0;
                    break;
                case StatType.Spd:
                    opponent.PenaltyNeutralizationManager.Spd = 0;
                    break;
                case StatType.Def:
                    opponent.PenaltyNeutralizationManager.Def = 0;
                    break;
                case StatType.Res:
                    opponent.PenaltyNeutralizationManager.Res = 0;
                    break;
                case StatType.HP:
                    opponent.PenaltyNeutralizationManager.HP = 0;
                    break;
            }
        }
    } 
}