Public Class PentagonalNumberCalculator
    Implements IPentagonalNumberCalculator

    Public Function CalculateSequence(ByVal n As Integer) As Integer() Implements IPentagonalNumberCalculator.CalculateSequence
        Dim sequence(n - 1) As Integer
        For i As Integer = 0 To n - 1
            sequence(i) = i * (3 * i - 1) \ 2
        Next
        Return sequence
    End Function
End Class