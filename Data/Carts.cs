using StorePrototype.Modals;

namespace StorePrototype.Data;

public class Carts{

   private readonly StoreItems _StoreItems;

   public Carts(StoreItems storeItems){
      _StoreItems=storeItems;
   }

   private int nextId=1;
   private static List<Cart> _Carts=new List<Cart>(){};
   private static List<(string,int)> _UserToCartRelation=new List<(string,int)>(){};

   private async Task<Cart?> GetCart(int cartId){
      var cart = await Task.FromResult(_Carts.Find(c=>c.Id==cartId));
      if(cart is not null){
         return cart;
      }
      return null;
   }

   public async Task<Cart?> GetCart(string username){
      var userCart=await Task.FromResult(_UserToCartRelation.Find(c=>c.Item1==username));
      if(!userCart.Equals(default)) return await Task.FromResult<Cart?>(await GetCart(userCart.Item2));
      return null;
   }

   public async void AddItemToCart(string user,int itemCode,int count){
      var cart =await GetCart(user);
      if(cart is null){
         MakeCart(user);
         cart=await GetCart(user);
      }
      var item=await _StoreItems.GetItemAsync(itemCode);
      if(cart is not null&&item is not null&&item.StockCount>=count){
         cart.AddItem(itemCode,count);
      }
   }

   public List<string> GetUsers(){
      return _UserToCartRelation.Select(i=>i.Item1).ToList();
   }

   public void MakeCart(string user){
      var cart=new Cart(_StoreItems){Id=nextId++,Shipping=3000};
      _Carts.Add(cart);
      _UserToCartRelation.Add( (user , cart.Id) );
   }

   public async void RemoveCart(int cartId){
      var cart=await GetCart(cartId);
      if(cart is not null){
         _Carts.Remove(cart);
         var userCart=_UserToCartRelation.Find(v=>v.Item2==cartId);
         _UserToCartRelation.Remove(userCart);
      }
   }

   public async void RemoveItemFromCart(string UserName,int itemId,int ammount){
      var cart=await GetCart(UserName);
      if(cart is null)return;
      // (itemId,Ammount)
      var listItem=cart.Contents.Find(v=>v.Item1==itemId);
      if(listItem.Equals(default)||listItem.Item2<ammount)return;
      cart.Contents.Remove(listItem);
      if(listItem.Item2!=ammount) cart.Contents.Add((itemId,listItem.Item2-ammount));
      var item=await _StoreItems.GetItemAsync(itemId);
      if(item is not null)item.StockCount=item.StockCount + ammount;
   }

   public async void DeleteItemFromCart(string UserName,int itemId){
      var cart=await GetCart(UserName);
      if(cart is null)return;
      // (itemId,Ammount)
      var listItem=cart.Contents.Find(v=>v.Item1==itemId);
      if(listItem.Equals(default))return;
      cart.Contents.Remove(listItem);
      var item=await _StoreItems.GetItemAsync(itemId);
      if(item is not null) item.StockCount=item.StockCount + listItem.Item2;
   }

   public async Task RemoveItemsFromCartWithoutReplacing(string username){
      var cart=await GetCart(username);
      if(cart is not null){
         cart.ResetCartWithoutReplaceingItems();
      }
   }
}