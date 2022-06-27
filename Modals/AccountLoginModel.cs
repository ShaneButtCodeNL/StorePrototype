using System.ComponentModel.DataAnnotations;

public class AccountLoginModel{
   [Required]
   public string? Name{get;set;}
   [Required]
   public string? AccountNumber{get;set;}
}