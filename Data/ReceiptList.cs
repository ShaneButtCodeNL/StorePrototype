using StorePrototype.Modals;
namespace StorePrototype.Data;

public class ReceiptList{
   private List<Receipt> ListOfReceipts=new List<Receipt>(){};

   public async Task<Receipt?> GetReceipt(int id){
      Receipt? rec=null;
      await Task.Run(()=>rec=ListOfReceipts.Find(x=>x.Id==id));
      if(rec is not null) return rec;
      return null;
   }

   public async Task<List<Receipt>?> GetReceiptListOfUser(string UserName){
      List<Receipt>? list=null;
      await Task.Run(()=>list=ListOfReceipts.FindAll(x=>x.UserName==UserName));
      if(list is not null) return list;
      return null;
   }

   public async Task<int?> AddReceipt(Receipt? receipt){
      if(receipt is not null){
         receipt.Id=ListOfReceipts.Count();
         await Task.Run(()=>ListOfReceipts.Add(receipt));
         return receipt.Id;
      }
      return null;
   }
}