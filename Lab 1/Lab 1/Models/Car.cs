using Lab_1.Filters;

namespace Lab_1.Models;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Model { get; set; }
    [YearValidate(60, 99, 1960, 2023)]
    public int ProductionDate { get; set; }
    public double Prise { get; set; }
    public string Type { get; set; }
    public Car(int id, string name, string model, int productionDate, double prise, string type)
    {
        Id = id;
        Name = name;
        Model = model;
        ProductionDate = productionDate;
        Prise = prise;
        Type = type;
    }
}
