using Nubank.CapitalGains.CLI.Configurations;
using Nubank.CapitalGains.CLI.Entities;
using Nubank.CapitalGains.CLI.Tests.Enums;

namespace Nubank.CapitalGains.CLI.Tests.Mocks
{
    public class CaseMock
    {
        public CaseMock(CaseName caseName, IEnumerable<Operation> operations, IEnumerable<Tax> taxesPaid)
        {
            CaseName = caseName;
            Operations = operations;
            TaxesPaid = taxesPaid;
        }

        public CaseName CaseName { get; }
        public IEnumerable<Operation> Operations { get; }
        public IEnumerable<Tax> TaxesPaid { get; }

        public static IEnumerable<object[]> GetAllCases()
        {
            yield return new object[]
            {
                new CaseMock(
                    CaseName.Case1,
                    new List<Operation>
                    {
                        new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 10.00m, Quantity = 100 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 15.00m, Quantity = 50 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 15.00m, Quantity = 50 })
                    },
                    new List<Tax>
                    {
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0)
                    }
                )
            };

            yield return new object[]
            {
                new CaseMock(
                    CaseName.Case2,
                    new List<Operation>
                    {
                        new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 10.00m, Quantity = 10000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 20.00m, Quantity = 5000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 5.00m, Quantity = 5000 })
                    },
                    new List<Tax>
                    {
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 10000),
                        new Tax(new OperationContext(0, 0, 0), 0)
                    }
                )
            };

            yield return new object[]
            {
                new CaseMock(
                    CaseName.Case3,
                    new List<Operation>
                    {
                        new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 10.00m, Quantity = 10000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 5.00m, Quantity = 5000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 20.00m, Quantity = 3000 })
                    },
                    new List<Tax>
                    {
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 1000)
                    }
                )
            };

            yield return new object[]
            {
                new CaseMock(
                    CaseName.Case4,
                    new List<Operation>
                    {
                        new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 10.00m, Quantity = 10000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 25.00m, Quantity = 5000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 15.00m, Quantity = 10000 })
                    },
                    new List<Tax>
                    {
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0)
                    }
                )
            };

            yield return new object[]
            {
                new CaseMock(
                    CaseName.Case5,
                    new List<Operation>
                    {
                        new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 10.00m, Quantity = 10000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 25.00m, Quantity = 5000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 15.00m, Quantity = 10000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 25.00m, Quantity = 5000 })
                    },
                    new List<Tax>
                    {
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 10000)
                    }
                )
            };

            yield return new object[]
            {
                new CaseMock(
                    CaseName.Case6,
                    new List<Operation>
                    {
                        new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 10.00m, Quantity = 10000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 2.00m, Quantity = 5000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 20.00m, Quantity = 2000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 20.00m, Quantity = 2000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 25.00m, Quantity = 1000 })
                    },
                    new List<Tax>
                    {
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 3000)
                    }
                )
            };

            yield return new object[]
            {
                new CaseMock(
                    CaseName.Case7,
                    new List<Operation>
                    {
                        new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 10.00m, Quantity = 10000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 2.00m, Quantity = 5000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 20.00m, Quantity = 2000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 20.00m, Quantity = 2000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 25.00m, Quantity = 1000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 20.00m, Quantity = 1000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 15.00m, Quantity = 5000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 30.00m, Quantity = 4350 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 30.00m, Quantity = 650 })
                    },
                    new List<Tax>
                    {
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 3000),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 3700),
                        new Tax(new OperationContext(0, 0, 0), 0),
                    }
                )
            };

            yield return new object[]
            {
                new CaseMock(
                    CaseName.Case8,
                    new List<Operation>
                    {
                        new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 10.00m, Quantity = 10000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 50.00m, Quantity = 10000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 20.00m, Quantity = 10000 }),
                        new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 50.00m, Quantity = 10000 })
                    },
                    new List<Tax>
                    {
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 80000),
                        new Tax(new OperationContext(0, 0, 0), 0),
                        new Tax(new OperationContext(0, 0, 0), 60000)
                    }
                )
            };
        }
    }

}
