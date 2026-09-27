using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace PetShopSystem.Entities;
public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]

    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Product(int id, string name, Category category, decimal price, int stock)
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        Stock = stock;
    }
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Category: {Category}, Price: {Price}, Stock: {Stock}";
    }
}
