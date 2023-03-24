Public Class FibonacciLucasNumberCalculator
    Implements IFibonacciLucasNumberCalculator

    Public Function CalculateSequence(ByVal n As Integer) As Integer() Implements IFibonacciLucasNumberCalculator.CalculateSequence
        Dim sequence(n - 1) As Integer
        For i As Integer = 0 To n - 1
            If i = 0 Then
                sequence(i) = 2
            ElseIf i = 1 Then
                sequence(i) = 1
            Else
                sequence(i) = sequence(i - 1) + sequence(i - 2)
            End If
        Next
        Return sequence
    End Function
End Class