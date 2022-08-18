using System.ComponentModel.DataAnnotations;

public class Board
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }
    public string Manufacturer { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}