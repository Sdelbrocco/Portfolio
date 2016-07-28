using System;

namespace FlooringProgram.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal Area { get; set; }

        public Product ProductOrdered { get; set; }
        public Tax State { get; set; }
        public DateTime OrderDate { get; set; }
       
        // Get the property such that the function needs to happen first
        // before the result is returned
        public decimal TaxCost =>  ((ProductOrdered.LaborCostPerSquareFoot + MaterialCost)*State.TaxRate)/100;
        public decimal LaborCost => (ProductOrdered.LaborCostPerSquareFoot)*Area;
        public decimal TotalCost => MaterialCost + LaborCost + TaxCost;
        public decimal MaterialCost => ProductOrdered.CostPerSquareFoot*Area;

    }
}
