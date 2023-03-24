Public Class HarmonicNumberCalculator
    Implements IHarmonicNumberCalculator

    Public Function CalculateSequence(ByVal n As Integer) As Double() Implements IHarmonicNumberCalculator.CalculateSequence
        Dim sequence(n - 1) As Double
        For i As Integer = 0 To n - 1
            sequence(i) = CalculateHarmonicNumber(i + 1)
        Next
        Return sequence
    End Function

    Private Function CalculateHarmonicNumber(ByVal n As Integer) As Double
        Dim sum As Double = 0
        For i As Integer = 1 To n
            sum += 1 / i
        Next
        Return sum
    End Function
End Class