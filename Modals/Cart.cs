using StorePrototype.Data;

namespace StorePrototype.Modals;

public class Cart{
   public int Id{get;set;}

   public StoreItems _Items;

   public Cart(StoreItems items){
      _Items=items;
   }
   public int Shipping{get;set;}

   // Itemcode,count
   public List<(int,int)> Contents{get;set;}=new List<(int,int)>(){};

   public async void AddItem(int itemCode ,int itemCount){

      var listItem=Contents.Find(i=>i.Item1==itemCode);
      var item=await _Items.GetItemAsync(itemCode);
      if(item is null)return;
      //Not already in cart add
      if(listItem.Equals(default)){
         if(itemCount<=item.StockCount){
            item.StockCount-=itemCount;
            Contents.Add( (itemCode,itemCount) );
         }
      }
      //Already in cart increment
      else{
         if(listItem.Item2+itemCount<=item.StockCount){
            item.StockCount-=itemCount;
            Contents.Remove(listItem);
            Contents.Add((listItem.Item1,listItem.Item2+itemCount));
         }
      }
   }

   public void RemoveItem(int itemCode,int count){
      if(count==0)return;
      var listItem=Contents.Find(i=>i.Item1==itemCode);
      //Not in cart
      if(listItem.Equals(default))return;
      //Remove item from cart if ammount would be 0 or less
      if(listItem.Item2<=count){
         Contents.Remove(listItem);
         return;
      }
      //Decrement item count
      //listItem.Item2-=count;
      Contents.Remove(listItem);
      Contents.Add((listItem.Item1,listItem.Item2-count));
   }

   public void ResetCartWithoutReplaceingItems(){
      Contents=new List<(int,int)>(){};
   }

   public async Task<(int,int,int)> CartCost(){
      double subTotal=0;
      double taxTotal=0.0;
      double discountTotal=0.0;
      foreach(var itemPair in Contents){
         var item = await _Items.GetItemAsync(itemPair.Item1);
         if(item is null)continue;
         var cost=item.Price*itemPair.Item2;
         subTotal+=cost;
         var discountCost=cost*(Math.Min(1.0,item.Discount+item.Sale));
         discountTotal+=discountCost;
         taxTotal+=(cost-discountCost)*item.TaxValue;
      }
      return (
         (int)Math.Round(discountTotal),
         (int)Math.Round(taxTotal),
         (int)Math.Round(subTotal)
      );
   }

   public int CountStockInCart(){
      int count=0;
      foreach(var item in Contents) count+=item.Item2;
      return count;
   }
}