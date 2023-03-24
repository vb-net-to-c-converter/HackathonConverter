Module MainModule

    Sub Main()
        Dim catalanNumberCalculator As ICatalanNumberCalculator = New CatalanNumberCalculator()
        Console.WriteLine("Result of CatalanNumberCalculator(3)")
        Console.WriteLine(catalanNumberCalculator.CalculateSequence(3).ToString())

        Dim factorialCalculator As IFactorialCalculator = New FactorialCalculator()
        Console.WriteLine("Result of FactorialCalculator(3)")
        Console.WriteLine(factorialCalculator.CalculateSequence(3).ToString())

        Dim fibonacciCalculator As IFibonacciCalculator = New FibonacciCalculator()
        Console.WriteLine("Result of FibonacciCalculator(3)")
        Console.WriteLine(fibonacciCalculator.CalculateSequence(3).ToString())

        Dim fibonacciLucasNumberCalculator As IFibonacciLucasNumberCalculator = New FibonacciLucasNumberCalculator()
        Console.WriteLine("Result of FibonacciLucasNumberCalculator(3)")
        Console.WriteLine(fibonacciLucasNumberCalculator.CalculateSequence(3).ToString())

        Dim harmonicNumberCalculator As IHarmonicNumberCalculator = New HarmonicNumberCalculator()
        Console.WriteLine("Result of HarmonicNumberCalculator(3)")
        Console.WriteLine(harmonicNumberCalculator.CalculateSequence(3).ToString())

        Dim pellNumberCalculator As IPellNumberCalculator = New PellNumberCalculator()
        Console.WriteLine("Result of PellNumberCalculator(3)")
        Console.WriteLine(pellNumberCalculator.CalculateSequence(3).ToString())

        Dim pentagonalNumberCalculator As IPentagonalNumberCalculator = New PentagonalNumberCalculator()
        Console.WriteLine("Result of PentagonalNumberCalculator(3)")
        Console.WriteLine(pentagonalNumberCalculator.CalculateSequence(3).ToString())

        Dim primeNumberCalculator As IPrimeNumberCalculator = New PrimeNumberCalculator()
        Console.WriteLine("Result of PrimeNumberCalculator(3)")
        Console.WriteLine(primeNumberCalculator.CalculateSequence(3).ToString())

        Dim squareNumberCalculator As ISquareNumberCalculator = New SquareNumberCalculator()
        Console.WriteLine("Result of SquareNumberCalculator(3)")
        Console.WriteLine(squareNumberCalculator.CalculateSequence(3).ToString())

        Dim triangularNumberCalculator As ITriangularNumberCalculator = New TriangularNumberCalculator()
        Console.WriteLine("Result of TriangularNumberCalculator(3)")
        Console.WriteLine(triangularNumberCalculator.CalculateSequence(3).ToString())

        Console.ReadLine()
    End Sub

End Module
