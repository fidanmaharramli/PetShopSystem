using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace PetShopSystem.Entities;
public class Customer
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]

    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Customer(int id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Age: {Age}";
    }
}
