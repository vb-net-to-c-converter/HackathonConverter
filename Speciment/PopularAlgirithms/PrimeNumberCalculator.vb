Public Class PrimeNumberCalculator
    Implements IPrimeNumberCalculator

    Public Function CalculateSequence(ByVal n As Integer) As Integer() Implements IPrimeNumberCalculator.CalculateSequence
        Dim sequence(n - 1) As Integer
        Dim count As Integer = 0
        Dim number As Integer = 2
        While count < n
            If IsPrime(number) Then
                sequence(count) = number
                count += 1
            End If
            number += 1
        End While
        Return sequence
    End Function

    Private Function IsPrime(ByVal n As Integer) As Boolean
        If n <= 1 Then
            Return False
        ElseIf n = 2 Or n = 3 Then
            Return True
        ElseIf n Mod 2 = 0 Or n Mod 3 = 0 Then
            Return False
        End If

        Dim i As Integer = 5
        While i * i <= n
            If n Mod i = 0 Or n Mod (i + 2) = 0 Then
                Return False
            End If
            i += 6
        End While
        Return True
    End Function
End Class