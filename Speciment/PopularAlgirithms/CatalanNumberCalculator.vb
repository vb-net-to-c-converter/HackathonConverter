Public Class CatalanNumberCalculator
    Implements ICatalanNumberCalculator

    Public Function CalculateSequence(ByVal n As Integer) As Integer() Implements ICatalanNumberCalculator.CalculateSequence
        Dim sequence(n - 1) As Integer
        For i As Integer = 0 To n - 1
            sequence(i) = CalculateCatalanNumber(i + 1)
        Next
        Return sequence
    End Function

    Private Function CalculateCatalanNumber(ByVal n As Integer) As Integer
        If n <= 1 Then
            Return 1
        Else
            Dim result As Integer = 0
            For i As Integer = 0 To n - 1
                result += CalculateCatalanNumber(i) * CalculateCatalanNumber(n - i - 1)
            Next
            Return result
        End If
    End Function
End Class