namespace StorePrototype.Modals;

//Represents a item displayed for sale
public class StoreItem{
   /**
   Gets the double representation of a price
   **/
   private double GetPrice()=>((double)_price)/100.0;
   /**
   Changes the price of an item takes in a decimal value and converts it to cents
   **/
   private void SetPriceAsInt(double newPrice){
      _price=(int)Math.Floor(newPrice*100);
   }
   private int _price;

   
   //Price stored in cents same format as american/canadian money
   public double Price{
      get=>GetPrice();
      set=>SetPriceAsInt(value);
   }
   public string Name{get;set;}="";
   public string Description{get;set;}="";
   public int StockCount{get;set;}=0;
   public int ItemCode{get;set;}
   public string ImageLocation{get;set;}="";
   public double TaxValue{get;set;}=0;
   public double Sale{get;set;}=0.0;
   public double Discount{get;set;}=0.0;
   //
   // TODO Currency type implement later
   //
   private string CurrencyType{get;set;}="Canadian";

}