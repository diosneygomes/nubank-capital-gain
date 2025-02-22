using Nubank.CapitalGains.CLI.Implementations.Services;
using Nubank.CapitalGains.CLI.Tests.Configuration;
using Nubank.CapitalGains.CLI.Tests.Enums;
using Nubank.CapitalGains.CLI.Tests.Mocks;

namespace Nubank.CapitalGains.CLI.Tests.Services
{
    public class CalculateServiceTest : IClassFixture<TestFixture>
    {
        private readonly CalculateService _calculateService;

        public CalculateServiceTest(TestFixture fixture)
        {
            _calculateService = new CalculateService(fixture.HandlerFactory);
        }

        [Theory]
        [MemberData(nameof(CaseMock.GetAllCases), MemberType = typeof(CaseMock))]
        public void CalculateServiceHandleCasesCorrectly(CaseMock caseMock)
        {
            
            var operations = caseMock.Operations;
            
            var taxesPaid = caseMock.TaxesPaid;

            var results = _calculateService.CalculateCapitalGainsTaxes(operations);
            
            switch (caseMock.CaseName)
            {
                case CaseName.Case1:
                    Assert.Equal(CaseName.Case1, caseMock.CaseName);
                    break;
                case CaseName.Case2:
                    Assert.Equal(CaseName.Case2, caseMock.CaseName);
                    break;
                case CaseName.Case3:
                    Assert.Equal(CaseName.Case3, caseMock.CaseName);
                    break;
                case CaseName.Case4:
                    Assert.Equal(CaseName.Case4, caseMock.CaseName);
                    break;
                case CaseName.Case5:
                    Assert.Equal(CaseName.Case5, caseMock.CaseName);
                    break;
                case CaseName.Case6:
                    Assert.Equal(CaseName.Case6, caseMock.CaseName);
                    break;
                case CaseName.Case7:
                    Assert.Equal(CaseName.Case7, caseMock.CaseName);
                    break;
                case CaseName.Case8:
                    Assert.Equal(CaseName.Case8, caseMock.CaseName);
                    break;
                default:
                    Assert.Fail($"CaseName não esperado: {caseMock.CaseName}");
                    break;
            }

            Assert.Equal(taxesPaid.Count(), results.Count());

            for (int i = 0; i < taxesPaid.Count(); i++)
            {               
                Assert.Equal(taxesPaid.ElementAt(i).TaxPaid, results.ElementAt(i).TaxPaid);
            }
        }
    }
}
