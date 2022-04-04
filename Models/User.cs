using System.ComponentModel.DataAnnotations;

namespace UserApi.Models;

public class User
{
  public long Id {get;set;}

	[Required(ErrorMessage = "Full name is required.")]
  public string? FullName {get;set;}

	[Required(ErrorMessage = "Email is required.")]
	[RegularExpression(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$", ErrorMessage = "Email is required.")]
  public string? Email {get;set;}

  public string? Phone {get;set;}

  public int? Age {get;set;}
}