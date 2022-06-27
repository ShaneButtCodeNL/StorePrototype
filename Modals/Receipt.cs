namespace StorePrototype.Modals;
public class Receipt{
   public int Id{get;set;}

   public string? UserName{get;set;}

   public string? AccountName{get;set;}

   public DateTime? ReceiptDate{get;set;}

   public List<(StoreItem,int)>? Items{get;set;}

   public double SubTotal {get;set;}=0;

   public double Discount {get;set;}=0;

   public double TaxedAmmount{get;set;}

   public double Shipping {get;set;}=0;
   public string Status {get;set;}="Pending";
}