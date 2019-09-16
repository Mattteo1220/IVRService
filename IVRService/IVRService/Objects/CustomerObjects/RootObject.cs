using System.Collections.Generic;

namespace IVRService.Objects.CustomerObjects
{
  public class RootObject
  {
    public CustomerObject result { get; set; }
    public List<Ineligible> ineligible { get; set; }
    public List<string> commands { get; set; }
  }
}
