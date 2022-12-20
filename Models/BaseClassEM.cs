namespace Models;

public class BaseClassEM
{
    int age { get; set; }
    string? phonNumner { get; set; }
    
    bool sex { get; set; }
    Address adrass { get; set; }

    public BaseClassEM(int age, string? phonNumner, Address adrass, bool sex)
    {
        this.age = age;
        this.adrass = adrass;
        this.phonNumner = phonNumner;
        this.sex = sex;
    }
}
