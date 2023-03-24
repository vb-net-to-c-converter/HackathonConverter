Public Class FactorialCalculator
    Implements IFactorialCalculator

    Public Function CalculateSequence(ByVal n As Integer) As Integer() Implements IFactorialCalculator.CalculateSequence
        Dim sequence(n - 1) As Integer
        For i As Integer = 0 To n - 1
            sequence(i) = Factorial(i + 1)
        Next
        Return sequence
    End Function

    Private Function Factorial(ByVal n As Integer) As Integer
        If n <= 1 Then
            Return 1
        Else
            Return n * Factorial(n - 1)
        End If
    End Function
End Class