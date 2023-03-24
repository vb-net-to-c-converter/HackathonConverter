Public Class TriangularNumberCalculator
    Implements ITriangularNumberCalculator

    Public Function CalculateSequence(ByVal n As Integer) As Integer() Implements ITriangularNumberCalculator.CalculateSequence
        Dim sequence(n - 1) As Integer
        For i As Integer = 0 To n - 1
            sequence(i) = (i + 1) * (i + 2) \ 2
        Next
        Return sequence
    End Function
End Class