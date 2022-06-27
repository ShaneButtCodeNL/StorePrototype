namespace StorePrototype.Services;
public class LoginServices{
   public async Task Login(){
      if(MainLoginEvent!=null){
         await MainLoginEvent.Invoke();
         if(LoginEvent!=null&&UserName!=null){
            await LoginEvent.Invoke(UserName);
            UserName=null;
         }
      }
   }
   public async Task Logout(){
      if(MainLogoutEvent!=null){
         await MainLogoutEvent.Invoke();
         if(LogoutEvent!=null){
            await LogoutEvent.Invoke();
         }
      }
   }
   //Login and Logouts
   public event Func<Task>? MainLoginEvent;
   public event Func<Task>? MainLogoutEvent;
   //Events that occur when logging in or out
   public event Func<string,Task>? LoginEvent;
   public event Func<Task>? LogoutEvent;

   public string? UserName;
}