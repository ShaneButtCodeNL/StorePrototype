using StorePrototype.Modals;

namespace StorePrototype.Data;

public class StoreItems{

   public StoreItems(){}
   //Default image height
   private const int ImageHeight=300;
   //Default image width
   private const int ImageWidth=200;
   private static int rand=1;
   //will get a Random image each call
   private static readonly string ImageString=$"https://picsum.photos/{ImageWidth.ToString()}/{ImageHeight.ToString()}";

   //List of items for the store
   private static List<StoreItem> _storeItems=new List<StoreItem>(){
      new StoreItem(){
            Name="Alpha",
            ItemCode=1 ,
            Price=1999,
            ImageLocation=ImageString+"?random="+rand++,
            StockCount=0,
            Description="This is Item Alpha"
      },
      new StoreItem(){
            Name="Beta",
            ItemCode=2 ,
            Price=99,
            ImageLocation=ImageString+"?random="+rand++,
            StockCount=10000,
            Description="This is Item Beta"
      },
      new StoreItem(){
            Name="Gamma",
            ItemCode=3 ,
            Price=23900,
            ImageLocation=ImageString+"?random="+rand++,
            StockCount=10,
            Description="This is Item Gamma"
      },
      new StoreItem(){
            Name="Delta",
            ItemCode=4 ,
            Price=2390,
            ImageLocation=ImageString+"?random="+rand++,
            StockCount=120,
            Description="This is Item Delta"
      },
      new StoreItem(){
            Name="Sigma",
            ItemCode=5 ,
            Price=9,
            ImageLocation=ImageString+"?random="+rand++,
            StockCount=5,
            Description="This is Item Sigma"
      },
   };

   private async Task<List<StoreItem>> CopyList(){
      await Task.Delay(2000);
      List<StoreItem> list=new List<StoreItem>(){};
      foreach(var i in _storeItems){
         list.Add(i);
      }
      return list;
   }
 
   //Adds n items to the list
   public async void AddRandomItems(int n){
      await Task.Run(()=>{
         var count=_storeItems.Count()+1;
         for(int i=0;i<n;i++){
            _storeItems.Add(new StoreItem(){
               Name=$"Item{count}",
               ItemCode=count ,
               Price=new Random().Next(1,10000),
               ImageLocation=ImageString+"?random="+rand++,
               StockCount=new Random().Next(1000),
               Description=$"This is Item{count}"
            });
            count++;
         }
      });
   }

   public async Task<List<StoreItem>> GetStoreItemsAsync(){
      return await Task.FromResult<List<StoreItem>>( await CopyList() );
   }

   public async Task<StoreItem?> GetItemAsync(int id){
      var item = await Task.FromResult(_storeItems.Find(i=>i.ItemCode==id));
      if(item is not null)return item;
      return null;
   }

   public async Task<int> RemoveItem(int n,int itemCode){
      return await new Task<int>(()=>{
         var item= _storeItems.Find(i=>i.ItemCode==itemCode);
         if(item is not null && item.StockCount>=n){
            item.StockCount-=n;
            return n;
         }
         return -1;
      });
   }
}