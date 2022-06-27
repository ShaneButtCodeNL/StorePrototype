namespace StorePrototype.Services;
public class ListUpdateService{
   public async Task Update(){
      if(ListChange!=null){
         await ListChange.Invoke();
      }
   }
   public async Task AddItem(){
      if(AddItemEvent is not null) await AddItemEvent.Invoke();
   }
  
   public event Func<Task>? ListChange;
   public event Func<Task>? AddItemEvent;
}