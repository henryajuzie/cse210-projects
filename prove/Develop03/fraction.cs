public class Fraction
{
    private int numerator;
    private int denominator;

    // Constructor that initializes the fraction to 1/1
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    // Constructor that initializes the fraction to a whole number (e.g., 5 => 5/1)
    public Fraction(int number)
    {
        numerator = number;
        denominator = 1;
    }

    // Constructor that initializes the fraction with numerator and denominator
    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    // Getters and setters for numerator and denominator
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    public int Denominator
    {
        get { return denominator; }
        set { denominator = value; }
    }

    // Method to return the fraction in the form "numerator/denominator"
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}
