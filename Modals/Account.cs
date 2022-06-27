namespace StorePrototype.Modals;

public class Account{
   private int balance;

   private void SetBalance(int ammount)=>balance=ammount;
   private void SetBalance(double ammount)=>balance=(int)ammount;

   public int AccountNumber{get;set;}

   public string Name{get;set;}="";

   public double Balance{
      get=>((double)balance)/100;
      set=>SetBalance(value);
   }

   public bool CanMakePurchase(int Ammount){
      return balance>=Ammount;
   }

   public void AddFunds(int ammount){
      balance+=ammount;
   }

   public void AddFunds(double ammount){
      this.AddFunds((int)(ammount*100));
   }

   public void RemoveFunds(int ammount){
      if(balance>=ammount)balance-=ammount;
   }

   public void RemoveFunds(double ammount){
      this.RemoveFunds((int)(ammount*100));
   }
   
}