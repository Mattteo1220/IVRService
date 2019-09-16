using IVRService.Enums;
using IVRService.Extensions;
using IVRService.Helpers;
using IVRService.Objects;
using NUnit.Framework;
using System;

namespace IVRService.Tests
{
  [TestFixture]
  public class CallerUnitTests
  {
    private Caller _caller;
    private const string ENGLISH = "English";
    private const string SPANISH = "Spanish";
    [SetUp]
    public void SetUp()
    {
      _caller = new Caller();
    }

    [Test]
    [TestCase("Development")]
    [TestCase("Production")]
    public void AuthenticationTest_SendingRequest_ReturnsTokenString(string environment)
    {
      _caller.Environment = environment;
      _caller.Authenticate();
      Assert.Multiple(() =>
      {
        Assert.IsNotEmpty(_caller.AuthToken);
        Assert.IsNotNull(_caller.AuthToken);
      });
    }

    [Test]
    [TestCase(8885215111, ExpectedResult = Department.CustomerSupport)]
    [TestCase(8555527378, ExpectedResult = Department.CustomerSupport)]
    [TestCase(8016699504, ExpectedResult = Department.CustomerSupport)]
    [TestCase(8332222112, ExpectedResult = Department.RetailerSupport)]
    [TestCase(8552827378, ExpectedResult = Department.RetailerSupport)]
    [TestCase(8882456111, ExpectedResult = Department.Collections)]
    public Department Department_CallInDnis_ReturnsCorrectLeasingDepartment(long dnis)
    {
      var environment = "Development";
      var ani = 1112223344;
      var dtmf = 0;
      return CallBaseHelper.Department[dnis];
    }

    [Test]
    [TestCase(8885215111, ExpectedResult = (int)Department.CustomerSupport)]
    [TestCase(8555527378, ExpectedResult = (int)Department.CustomerSupport)]
    [TestCase(8016699504, ExpectedResult = (int)Department.CustomerSupport)]
    [TestCase(8332222112, ExpectedResult = (int)Department.RetailerSupport)]
    [TestCase(8552827378, ExpectedResult = (int)Department.RetailerSupport)]
    [TestCase(8882456111, ExpectedResult = (int)Department.Collections)]
    public int DepartmentHoursOfOperation_DnisCallIn_ReturnsCorrectHoursOfOperation(long dnis)
    {
      var environment = "Development";
      var ani = 1112223344;
      var dtmf = 0;
      return (int)CallBaseHelper.Department[dnis];
    }

    [Test]
    [TestCase(8885215111, ExpectedResult = LeasingCompany.KornerstoneCredit)]
    [TestCase(8555527378, ExpectedResult = LeasingCompany.CrestFinancial)]
    [TestCase(8016699504, ExpectedResult = LeasingCompany.AcceptanceRental)]
    [TestCase(8332222112, ExpectedResult = LeasingCompany.KornerstoneCredit)]
    [TestCase(8552827378, ExpectedResult = LeasingCompany.KornerstoneCredit)]
    [TestCase(8882456111, ExpectedResult = LeasingCompany.KornerstoneCredit)]
    public LeasingCompany LeasingCompany_CallInDnis_ReturnsCorrectLeasingComapny(long dnis)
    {
      var environment = "Development";
      var ani = 1112223344;
      var dtmf = 0;
      return CallBaseHelper.LLCType[dnis];
    }

    [Test]
    [TestCase(0, ExpectedResult = ENGLISH)]
    [TestCase(1, ExpectedResult = ENGLISH)]
    [TestCase(2, ExpectedResult = ENGLISH)]
    [TestCase(3, ExpectedResult = ENGLISH)]
    [TestCase(4, ExpectedResult = ENGLISH)]
    [TestCase(5, ExpectedResult = ENGLISH)]
    [TestCase(6, ExpectedResult = ENGLISH)]
    [TestCase(7, ExpectedResult = ENGLISH)]
    [TestCase(8, ExpectedResult = SPANISH)]
    [TestCase(9, ExpectedResult = ENGLISH)]
    public string Language_LanguageDtmfEntered_ReturnsCorrectLanuage(int dtmf)
    {
      var environment = "Development";
      var ani = 1112223344;
      return dtmf == 8 ? "Spanish" : "English";
    }

    [Test]
    public void VerifyCaller()
    {
      _caller.Environment = "Development";
      _caller.OriginalDepartment = Department.CustomerSupport;
      var ssn = 2832;
      var dob = DateTime.Parse("1972-02-20");
      _caller.Dnis = 8885215111;
      _caller.Ani = 5612948198;
      _caller.MasterId = 123;
      _caller.VerifyCallHandler(_caller.Ani, _caller.Dnis, _caller.Environment, "", ssn, dob, _caller.MasterId);
    }

    [Test]
    public void TestContext()
    {
      var language = "English";
      var _skill = new Skill();
      _skill.SkillId = language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? (int)SkillSet.VIPRetailerEnglish : (int)SkillSet.VIPRetailerSpanish;
      _skill.SkillName = language.Equals("English", StringComparison.InvariantCultureIgnoreCase) ? EnumExtensions.GetDescription(SkillSet.VIPRetailerEnglish) : EnumExtensions.GetDescription(SkillSet.VIPRetailerSpanish);
    }

  }
}
