namespace Fire_Emblem;

public class ActivationConditionFinder
{
    public bool IsActiveOnUnitStartsCombat(string description)
    {
        const string requiredText = "unidad inicia el combate";
        return description.Contains(requiredText);
    }
    
    public bool IsActiveOnOpponentStartsCombat(string description)
    {
        const string requiredText = "rival inicia el combate";
        return description.Contains(requiredText);
    }
    
    public bool IsActiveOnUnitHPCertainRange(string description)
    {
        const string requiredText = "HP de la unidad";
        return description.Contains(requiredText);
    }
    
    public bool IsActiveOnOpponentHPCertainRange(string description)
    {
        const string requiredText = "HP del rival ";
        return description.Contains(requiredText);
    }
    
    public bool IsActiveOnMostRecentOpponent(string description)
    {
        const string requiredText = "oponente más reciente";
        return description.Contains(requiredText);
    }
    
    public bool IsActiveOnUnitUsesSword(string description)
    {
        const string requiredText = "espada";
        return description.Contains(requiredText);
    }
    
    public bool IsActiveOnUnitUsesLance(string description)
    {
        const string requiredText = "lanza";
        return description.Contains(requiredText);
    }
    
    public bool IsActiveOnUnitUsesAxe(string description)
    {
        const string requiredText = "hacha";
        return description.Contains(requiredText);
    }
    
    public bool IsActiveOnUnitUsesBow(string description)
    {
        const string requiredText = "al usar un arco";
        return description.Contains(requiredText);
    }
    
    public bool IsActiveOnUnitUsesMagic(string description)
    {
        const string requiredText = "al usar magia";
        return description.Contains(requiredText);
    }
    
    public bool IsActiveOnOpponentUsesMagicOrBow(string description)
    {
        const string requiredText = "rival inicia el combate usando magia o arco";
        return description.Contains(requiredText);
    }
    
    public bool IsActiveOnMaleOpponent(string description)
    {
        const string requiredText = "rival es hombre";
        return description.Contains(requiredText);
    }
    
    public bool IsActiveOnUnitUsingOppositeTypeOfWeapon(string description)
    {
        const string requiredText = "con un ataque físico contra un rival armado con magia, o viceversa";
        return description.Contains(requiredText);
    }
}