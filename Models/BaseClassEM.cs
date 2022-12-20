namespace Models;

public class BaseClassEM
{
    int age { get; set; }
    string? phonNumner { get; set; }
    
    bool sex { get; set; }
    Adrass adrass { get; set; }

    public BaseClassEM(int age, string? phonNumner, Adrass adrass, bool sex)
    {
        this.age = age;
        this.adrass = adrass;
        this.phonNumner = phonNumner;
        this.sex = sex;
    }
}
