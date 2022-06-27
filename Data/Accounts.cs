using StorePrototype.Modals;

namespace StorePrototype.Data;

public class Accounts{
   private static List<Account> _accounts=new List<Account>{new Account(){Name="Account0",Balance=123456,AccountNumber=0}};

   public void MakeAccount(int balance){
      if(balance>=0){
         _accounts.Add(new Account(){Name=$"Account{_accounts.Count()}",AccountNumber=_accounts.Count(),Balance=balance});
      }
   }

   private Account? GetAccount(int accno){
      var acc=_accounts.Find(x=>x.AccountNumber==accno);
      if(acc is not null)return acc;
      return null;
   }
   public async Task<Account?> GetAccountAsync(string? name,int? accNo){
      if(name is null || accNo is null)return null;
      var acc=await Task.Run(()=>_accounts.Find(x=>x.AccountNumber==accNo && x.Name==name));
      if(acc is not null) return acc;
      return null;
   }
   public async Task<List<Account>> GetListOfAccountDetails(){
      var t= Task<List<Account>>.Run( ()=>{
         List<Account> arr= new List<Account>(){};
         foreach(Account a in _accounts){
            arr.Add(a);
         }
         return arr;
      });
      var res= await t;
      return res;
   }

   public async Task<bool> MakePurchase(int accountNumber,int cost){
      var t=false;
      await Task.Run(async ()=>{
         var acc=await CanMakePurchaseAsync(accountNumber,cost);
         if(acc is not null){
            acc.RemoveFunds(cost);
            //todo make recipt
            t=true;
         }
      });
      return t;
   }

   public async void AddFunds(int accountNumber,int ammount){
      var acc=await Task.FromResult(_accounts.Find(a=>a.AccountNumber==accountNumber));
      if(acc is not null){
         acc.AddFunds(ammount);
      }
   }

   private async Task<Account?> CanMakePurchaseAsync(int accountNumber,int cost){
      Account? acc=null;
      await Task.Run(()=>acc=CanMakePurchase(accountNumber,cost));
      return acc;
   }
   private Account? CanMakePurchase(int accountNumber,int cost){
      var acc= GetAccount(accountNumber);
      if(acc is not null && acc.CanMakePurchase(cost)){
         return acc;
      }
      return null;
   }
}