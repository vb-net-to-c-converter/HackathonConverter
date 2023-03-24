Public Class SquareNumberCalculator
    Implements ISquareNumberCalculator

    Public Function CalculateSequence(ByVal n As Integer) As Integer() Implements ISquareNumberCalculator.CalculateSequence
        Dim sequence(n - 1) As Integer
        For i As Integer = 0 To n - 1
            sequence(i) = (i + 1) ^ 2
        Next
        Return sequence
    End Function
End Class