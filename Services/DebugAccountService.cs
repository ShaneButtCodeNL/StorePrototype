namespace StorePrototype.Services;

public class DebugAccountService{
   public async Task GetAccountData(){
      if(GetData is not null) await GetData.Invoke();
   }

   public event Func<Task>? GetData;
}