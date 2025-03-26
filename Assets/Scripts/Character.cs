public partial class Character
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Level { get; private set; }
    public int CurEXP { get; private set; }
    public int MaxEXP { get; private set; }
    public int ATK { get; private set; }
    public int DEF { get; private set; }
    public int HP { get; private set; }
    public int CRIT { get; private set; }

    public Character(string name, string description, int level, int curExp, int maxExp,int atk, int def, int hp, int crit)
    {
        Name = name;
        Description = description;
        Level = level;
        CurEXP = curExp;
        MaxEXP = maxExp;
        ATK = atk;
        DEF = def;
        HP = hp;
        CRIT = crit;
    }
}
