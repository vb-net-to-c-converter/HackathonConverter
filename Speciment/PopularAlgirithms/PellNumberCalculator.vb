Public Class PellNumberCalculator
    Implements IPellNumberCalculator

    Public Function CalculateSequence(ByVal n As Integer) As Integer() Implements IPellNumberCalculator.CalculateSequence
        Dim sequence(n - 1) As Integer
        For i As Integer = 0 To n - 1
            sequence(i) = CalculatePellNumber(i + 1)
        Next
        Return sequence
    End Function

    Private Function CalculatePellNumber(ByVal n As Integer) As Integer
        If n = 1 Then
            Return 0
        ElseIf n = 2 Then
            Return 1
        Else
            Dim a As Integer = 0
            Dim b As Integer = 1
            For i As Integer = 3 To n
                Dim c As Integer = 2 * b + a
                a = b
                b = c
            Next
            Return b
        End If
    End Function
End Class