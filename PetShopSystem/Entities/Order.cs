using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace PetShopSystem.Entities;
public  class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]

    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public Order(int id, int customerId, int productId, int quantity, decimal totalPrice)
    {
        Id = id;
        CustomerId = customerId;
        ProductId = productId;
        Quantity = quantity;
        TotalPrice = totalPrice;
    }
    public override string ToString()
    {
        return $"Order Id: {Id}, Customer Id: {CustomerId}, Product Id: {ProductId}, Quantity: {Quantity}, Total Price: {TotalPrice}";

    }
}
