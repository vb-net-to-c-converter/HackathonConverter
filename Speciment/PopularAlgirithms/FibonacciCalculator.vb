Public Class FibonacciCalculator
    Implements IFibonacciCalculator

    Public Function CalculateSequence(ByVal n As Integer) As Integer() Implements IFibonacciCalculator.CalculateSequence
        Dim sequence(n - 1) As Integer
        Dim a As Integer = 0
        Dim b As Integer = 1
        Dim c As Integer

        For i As Integer = 0 To n - 1
            If i = 0 Then
                sequence(i) = a
            ElseIf i = 1 Then
                sequence(i) = b
            Else
                c = a + b
                a = b
                b = c
                sequence(i) = c
            End If
        Next

        Return sequence
    End Function
End Class
