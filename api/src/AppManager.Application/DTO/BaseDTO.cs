using System;

namespace AppManager.Application.DTO
{
  public class BaseDTO
  {
    public int? Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
  }
}
