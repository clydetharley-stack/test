Imports System.CodeDom
Imports System.ComponentModel.Design.Serialization
Imports System.Deployment.Application
Imports System.IO
Imports System.Linq.Expressions
Imports System.Net.Configuration
Imports System.Runtime.CompilerServices
Imports System.Runtime.Remoting.Messaging
Imports System.Security
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Policy
Imports System.Timers


Module Module1
    Dim Sea(20, 20) As Char
    Dim tryX = 10, tryY As Integer
    Dim Torpedos As Integer
    Dim GameWon As Boolean = False
    Dim PlayAgain As Char
    Dim name As String
    Dim counts As Integer = 9
    Dim counter As Integer = 9
    Dim xh As Integer
    Dim bs As String
    Dim Grid(7, 7) As Char
    Dim difficulty As String = "o"
    Dim gamelost As Boolean = False
    Dim move1 As Boolean = False
    Dim standard As String
    Dim countq As Integer = 9
    Dim countk As Integer = 9
    Dim countb As Integer = 9
    Dim sunKs, sunkT, sunkq, sunkV, sunkU As Boolean
    Dim colour As String
    Dim rc As Integer


    Sub Main()
        Dim j As Boolean = False
        Console.WriteLine("if you would like to play battleships please enter y or enter c for connect four you may have to enter the input multiple times if there is an error ")
        bs = Console.ReadLine().ToLower
        If bs = "y" Then
Break:

            xh = 1
            Do
                Console.Clear()
                SetupGame()
                Console.WriteLine(" what is your name")
                name = Console.ReadLine
                Console.WriteLine("Welcome " & name & " to Battleships!")
                Console.WriteLine("Enemy ships are hidden somewhere at sea.")
                Console.WriteLine("if you would like the enemy to deploy the standard 5 ships enter s ")
                standard = Console.ReadLine().ToLower
                Console.WriteLine("You have only forty torpedos to find it.")
                Do
                    Console.WriteLine()
                    DrawGrid()
                    Console.WriteLine()
                    Console.WriteLine("You have " & Torpedos & " torpedos left.")
                    Console.WriteLine("Enter the row and column to aim your torpedo.")
                    Console.Write("x value? ")
                    tryY = Console.ReadLine
                    Console.Write("y value? ")
                    tryX = Console.ReadLine
                    If Sea(tryX, tryY) = "M" Or Sea(tryX, tryY) = "x" Then
                        Torpedos = Torpedos + 1
                        Console.WriteLine("you already shot there")
                    End If
                    If Sea(tryX, tryY) = "." Then Sea(tryX, tryY) = "M"
                    If Sea(tryX, tryY) = "s" Then
                        Sea(tryX, tryY) = "X"
                        counts = counts - 1
                        Console.Write("hit")
                    End If
                    If Sea(tryX, tryY) = "t" Then
                        Sea(tryX, tryY) = "X"
                        counter = counter - 1
                        Console.WriteLine("hit")
                    End If
                    If Sea(tryX, tryY) = "u" Then
                        Sea(tryX, tryY) = "X"
                        countb = countb - 1
                        Console.WriteLine("hit")
                    End If
                    If Sea(tryX, tryY) = "v" Then
                        Sea(tryX, tryY) = "X"
                        countk = countk - 1
                        Console.WriteLine("hit")
                    End If
                    If Sea(tryX, tryY) = "q" Then
                        Sea(tryX, tryY) = "X"
                        countq = countq - 1
                        Console.WriteLine("")
                    End If
                    If counts = 0 AndAlso Not sunKs Then
                        Console.WriteLine("you have sunk a ship")
                        sunKs = True
                    End If
                    If counter = 0 AndAlso Not sunkT Then
                        Console.WriteLine("This hit has sunken a ship")
                        sunkT = True
                    End If
                    If countq = 0 AndAlso Not sunkq Then
                        Console.WriteLine("This torpedo took a ship down")
                        sunkq = True
                    End If
                    If countk = 0 AndAlso Not sunkV Then
                        Console.WriteLine("You have sunken a ship keep it up ")
                        sunkV = True
                    End If
                    If countb = 0 AndAlso Not sunkU Then
                        Console.WriteLine("One ship sunk")
                        sunkU = True
                    End If
                    If counts = 0 AndAlso counter = 0 AndAlso countq = 0 AndAlso countk = 0 AndAlso countb = 0 Then
                        GameWon = True
                    End If
                    Torpedos = Torpedos - 1
                Loop Until Torpedos = 0 Or GameWon = True
                If GameWon = True Then
                    Console.WriteLine()
                    DrawGrid()
                    Console.WriteLine()
                    Console.WriteLine("Congratulations! " & name & " sank the enemy ship! It took " & 40 - Torpedos & " torpedos i hope you had fun playing my game")
                Else
                    Console.WriteLine()
                    DrawGrid()
                    Console.WriteLine()
                    Console.WriteLine("Unfortunately you have run out of torpedos and have lost the battle hopefully you will be able to claim victory in your next attempt")
                End If
                Console.WriteLine()
                Console.WriteLine("Do you want to play again? (y/n)")
                PlayAgain = Console.ReadLine()
            Loop Until PlayAgain = "n"
        ElseIf bs = "messiah" Then
            rc = (CInt(rnd) * 2 + 1)
            If rc = 0 Then
                Console.ForegroundColor = ConsoleColor.DarkMagenta
                Console.WriteLine("approved")
                GoTo Break
            ElseIf rc = 1 Then
                Console.ForegroundColor = ConsoleColor.DarkGray
                Console.WriteLine(";)")
                GoTo Break
            ElseIf rc = 2 Then
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine(":)")
                GoTo Break
            ElseIf rc = 3 Then
                Console.ForegroundColor = ConsoleColor.Cyan
                Console.WriteLine("you found the secret section yay are you proud")
                GoTo Break
            End If
        ElseIf bs = "c" Then
Connect:
            Do
                Do
                    If PlayAgain = "y" Then

                    End If
                    Console.Clear()
                    If j = False Then
                        For x = 1 To 7
                            For y = 1 To 7
                                Grid(x, y) = "."
                            Next
                        Next
                        j = True
                    End If
                    SetupGrid()
                    While difficulty <> "easy" And difficulty <> "hard"
                        Console.WriteLine("please select a difficulty easy or hard")
                        difficulty = Console.ReadLine().ToLower
                    End While


                    playermove()
                    SetupGrid()
                    Enemymove()
                    SetupGrid()

                    Console.WriteLine()

                    For i = 1 To 4
                        For c = 1 To 4
                            If Grid(i, c) = "M" And Grid(i, c + 1) = "M" And Grid(i, c + 2) = "M" And Grid(i, c + 3) = "M" Then
                                GameWon = True
                            ElseIf Grid(i, c) = "B" And Grid(i + 1, c) = "B" And Grid(i + 2, c) = "B" And Grid(i + 3, c) = "B" Then
                                gamelost = True
                            ElseIf Grid(i, c) = "M" And Grid(i + 1, c) = "M" And Grid(i + 2, c) = "M" And Grid(i + 3, c) = "M" Then
                                GameWon = True
                            ElseIf Grid(i, c) = "B" And Grid(i, c + 1) = "B" And Grid(i, c + 2) = "B" And Grid(i, c + 3) = "B" Then
                                gamelost = True
                            ElseIf Grid(i, c) = "M" And Grid(i + 1, c + 1) = "M" And Grid(i + 2, c + 2) = "M" And Grid(i + 3, c + 3) = "M" Then
                                GameWon = True
                            ElseIf Grid(i, c) = "B" And Grid(i + 1, c + 1) = "B" And Grid(i + 2, c + 2) = "B" And Grid(i + 3, c + 3) = "B" Then
                                gamelost = True
                            End If
                        Next
                    Next
                Loop Until GameWon = True Or gamelost = True
                If GameWon = True Then
                    Console.WriteLine(" Congratulations you won against my connect 4 thank you for playing i hope you had fun")
                ElseIf gamelost = True Then
                    Console.WriteLine("you lost better luck next time")
                End If
                While PlayAgain <> "y" And PlayAgain <> "n"
                    Console.WriteLine("Do you want to play again? enter n if you would like to stop enter y because you would like to continue")
                    PlayAgain = Console.ReadLine().ToLower
                End While
                If PlayAgain = "y" Then
                    j = False
                    GameWon = False
                    gamelost = False
                    PlayAgain = "a"
                End If
            Loop Until PlayAgain = "n"

        End If

    End Sub
    Sub playermove()
        tryX = 10
        While tryX > 7
            Console.WriteLine("please select a place to move your moves are represented by M and the enemies move is represented by B")
            tryY = Console.ReadLine()
            tryX = Int(tryY)
        End While
        For i = 1 To 7
            If Grid(tryX, i) = "." Then
                Grid(tryX, i) = "M"

                GoTo Here
            ElseIf i = 7 Then
                Console.WriteLine("error")
                GoTo Connect
            End If
        Next
Here:
        If tryX = 9999999999 Then
            Console.WriteLine("you shouldn't see this")
Connect:

        End If
    End Sub
    Sub SetupGrid()
        Console.Clear()
        Console.WriteLine("  1  2  3  4  5  6  7 ")



        For x = 1 To 7
            For y = 1 To 7
                If Grid(y, 8 - x) = "." Then
                    Console.Write("  .")
                ElseIf Grid(y, 8 - x) = "M" Then
                    Console.ForegroundColor = ConsoleColor.Yellow
                    Console.Write("  M")
                    Console.ResetColor()
                ElseIf Grid(y, 8 - x) = "B" Then
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("  B")
                    Console.ResetColor()
                End If

            Next
            Console.WriteLine()
        Next

    End Sub
    Sub Enemymove()
        Dim move As Integer
        Dim blank As Integer
        Dim count As Integer = 1
        Dim placed As Boolean = False
Now:
        Randomize()
        If difficulty = "easy" Then
            move = CInt(Int((7 * Rnd()) + 1))

            For i = 1 To 7
                If Grid(move, i) = "." Then
                    Grid(move, i) = "B"


                    GoTo This
                ElseIf i = 7 Then
                    Console.WriteLine("error")
                    GoTo Now
                End If
            Next
This:
        ElseIf difficulty = "hard" Then
            If move1 = False Then
                Do
                    move = CInt(Int(7 * Rnd()) + 1)

                Loop Until Grid(move, 7) = "."
                For d = 1 To 7
                    If Grid(move, d) = "." And Grid(move, d - 1) <> "." Then
                        Grid(move, d) = "B"
                        move1 = True
                        placed = True
                        GoTo Moved
                    End If

                Next
            Else
                For i = 0 To 7
                    For c = 1 To 7
                        If c <= 4 Then
                            If Grid(i, c) = "M" And Grid(i, c + 1) = "M" And Grid(i, c + 2) = "M" And Grid(i, c + 3) = "." And Grid(i, c + 4) = "." Then
                                If c + 3 = 1 OrElse Grid(i, c + 2) <> "." Then
                                    Grid(i, c + 4) = "B"
                                    placed = True
                                    GoTo Moved
                                End If
                            End If
                        End If
                        If i <= 4 Then
                            If Grid(i, c) = "M" And Grid(i + 1, c) = "M" And Grid(i + 2, c) = "M" And Grid(i + 3, c) = "M" And Grid(i + 4, c) = "." Then
                                Grid(i, c + 4) = "B"
                                placed = True
                                GoTo Moved
                            End If
                        End If
                        If i <= 4 Then
                            If c <= 4 Then
                                If Grid(i, c) = "M" And Grid(i + 1, c + 1) = "M" And Grid(i + 2, c + 2) = "M" And Grid(i + 3, c + 3) = "M" And Grid(i + 4, c + 4) = "." Then
                                    Grid(i + 4, c + 4) = "B"
                                    placed = True
                                    GoTo Moved
                                End If
                            End If
                            End If

                    Next
                    If placed Then Exit For

                Next
                If placed = False Then
                    For i = 1 To 7
                        For d = 1 To 7
                            If Grid(i, d) = "." And Grid(i, d - 1) = "B" Then
                                Grid(i, d) = "B"
                                GoTo Moved
                            ElseIf Grid(i, d) = "." And Grid(i - 1, d) = "B" Then
                                Grid(i, d) = "B"
                                GoTo Moved
                            Else
                                move = CInt(Int((7 * Rnd()) + 1))

                                For e = 1 To 7
                                    If Grid(move, e) = "." Then
                                        Grid(move, e) = "B"
                                        GoTo Moved
                                    End If
                                Next
                            End If
                        Next
                    Next
                End If

            End If
        End If
Moved:
    End Sub
    Sub DrawGrid()
        Dim x, y As Integer
        Console.WriteLine("     1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20")
        For x = 1 To 20
            If x >= 10 Then
                Console.Write(x & " ")
            Else
                Console.Write(x & "  ")
            End If
            For y = 1 To 20
                If Sea(x, y) = "t" Then
                    Console.ForegroundColor = ConsoleColor.Blue
                    Console.Write("  .")
                    Console.ForegroundColor = ConsoleColor.Gray
                End If
                If Sea(x, y) = "s" Then
                    Console.ForegroundColor = ConsoleColor.Blue
                    Console.Write("  .")
                    Console.ForegroundColor = ConsoleColor.Gray
                End If
                If Sea(x, y) = "v" Then
                    Console.ForegroundColor = ConsoleColor.Blue
                    Console.Write("  .")
                    Console.ForegroundColor = ConsoleColor.Gray
                End If
                If Sea(x, y) = "q" Then
                    Console.ForegroundColor = ConsoleColor.Blue
                    Console.Write("  .")

                    Console.ForegroundColor = ConsoleColor.Gray
                End If
                If Sea(x, y) = "u" Then
                    Console.ForegroundColor = ConsoleColor.Blue
                    Console.Write("  .")
                    Console.ForegroundColor = ConsoleColor.Gray
                End If
                If Sea(x, y) = "M" Then
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.Write("  M")
                    Console.ForegroundColor = ConsoleColor.Gray
                End If
                If Sea(x, y) = "X" Then
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("  X")
                    Console.ForegroundColor = ConsoleColor.Gray
                End If
                If Sea(x, y) = "." Then
                    Console.ForegroundColor = ConsoleColor.Blue
                    Console.Write("  .")
                    Console.ForegroundColor = ConsoleColor.Gray
                End If
            Next
            Console.WriteLine()
        Next
    End Sub
    Sub SetupGame()
        Randomize()
        Dim x, y As Integer
        Dim ShipY, ShipX As Integer
        Dim hold As Integer
        Dim count As Integer = 0
        Dim nint As Integer
        Dim break As Integer = 1
        Dim check As Integer = 0
        Dim lengths As Integer
        Dim lengtht As Integer
        Dim lengthq As Integer
        Dim lengthb As Integer
        Dim lengthk As Integer
        Dim sint As Integer = CInt(Rnd())
        Dim bint As Integer = CInt(Rnd())
        Dim kint As Integer = CInt(Rnd())
        sunKs = False
        sunkT = False
        sunkq = False
        sunkV = False
        sunkU = False
        If break = 0 Then


retry:

            Main()
        End If
        Torpedos = 40
        GameWon = False

        For x = 1 To 20
            For y = 1 To 20
                Sea(x, y) = "."
            Next
        Next


        Randomize()
        hold = 0
        Do
            ShipX = CInt(Rnd() * 19 + 1)
            ShipY = CInt(Rnd() * 19 + 1)
        Loop Until sea(ShipX, shipY) = "."
        Sea(ShipX, ShipY) = "v"
        If standard = "s" Then
            lengthb = 1
            lengthk = 2
            lengthq = 2
            lengths = 3
            lengtht = 4
        Else
            lengths = CInt(Int((6 * Rnd()) + 1))
            lengtht = CInt(Int((6 * Rnd()) + 1))
            lengthk = CInt(Int((6 * Rnd()) + 1))
            lengthq = CInt(Int((6 * Rnd()) + 1))
            lengthb = CInt(Int((6 * Rnd()) + 1))
        End If
        If count = 0 Then
                counts = lengths
                counter = lengtht
                countk = lengthk
                countq = lengthq
            countb = lengthb
            count = 1
        End If
            If sint = 0 Then
            For c = 0 To lengthk
Origin:
                Do
                    hold = CInt(Rnd() * 19 + 1)
                    If hold = 20 Then
                        If Sea(hold - 1, ShipY) = "v" And Sea(hold, ShipY) = "." Then
                            Sea(hold, ShipY) = "v"
                            c = c + 1
                            GoTo Origin
                        Else
                            GoTo Origin
                        End If


                        If Sea(hold, ShipY) = "t" Or Sea(hold, ShipY) = "s" Or Sea(hold, ShipY) = "v" Or Sea(hold, ShipY) = "q" Or Sea(hold, ShipY) = "u" Then
                            GoTo Origin
                        End If
                    End If
                    check = check + 1
                    If check = 400 Then
                        GoTo retry
                    End If
                Loop Until Sea(hold - 1, ShipY) = "v" Or Sea(hold + 1, shipY) = "v"
                Sea(hold, ShipY) = "v"
            Next
        Else
            For j = 0 To lengthk
Alpha:
                Do
                    hold = CInt(Rnd() * 8 + 1)
                    If hold = 9 Then
                        If Sea(ShipX, hold - 1) = "v" And Sea(ShipX, hold) = "." Then
                            Sea(ShipX, hold) = "v"
                            j = j + 1
                            GoTo Alpha
                        Else
                            GoTo Alpha
                        End If
                    End If
                    If Sea(ShipX, hold) <> "." Then
                        GoTo Alpha
                    End If
                Loop Until Sea(ShipX, hold - 1) = "v" Or Sea(ShipX, hold + 1) = "v"
                Sea(ShipX, hold) = "v"
            Next

        End If
        hold = 0
        Do
            ShipX = CInt(Rnd() * 19 + 1)
            ShipY = CInt(Rnd() * 19 + 1)
        Loop Until Sea(ShipX, shipy) = "."
        Sea(ShipX, ShipY) = "s"
        Dim rint As Integer = CInt(Rnd())
        If rint = 0 Then


            For c = 0 To lengths
startof:

                Do
                    hold = CInt(Rnd() * 19 + 1)
                    If hold = 20 Then
                        If Sea(hold - 1, ShipY) = "s" And Sea(hold, ShipY) = "." Then
                            Sea(hold, ShipY) = "s"
                            c = c + 1
                            GoTo startof
                        Else

                            GoTo startof


                        End If
                    End If
                    If Sea(hold, ShipY) = "t" Or Sea(hold, ShipY) = "s" Or Sea(hold, ShipY) = "v" Or Sea(hold, ShipY) = "q" Or Sea(hold, ShipY) = "u" Then
                        GoTo startof

                    End If
                    check = check + 1
                    If check = 421 Then

                        GoTo retry
                    End If
                Loop Until Sea(hold - 1, ShipY) = "s" Or Sea(hold + 1, ShipY) = "s"
                Sea(hold, ShipY) = "s"



            Next
        Else
            For j = 0 To lengths
beg:
                Do
                    hold = CInt(Rnd() * 19 + 1)
                    If hold = 20 Then
                        If Sea(ShipX, hold - 1) = "s" And Sea(ShipX, hold) = "." Then
                            Sea(ShipX, hold) = "s"
                            j = j + 1
                            GoTo beg
                        Else
                            GoTo beg
                        End If
                    End If
                    If Sea(ShipX, hold) = "s" Or Sea(ShipX, hold) = "t" Or Sea(hold, ShipY) = "v" Or Sea(hold, ShipY) = "q" Or Sea(hold, ShipY) = "u" Then
                        GoTo beg
                    End If
                    check = check + 1
                    If check = 400 Then
                        GoTo retry
                    End If

                Loop Until Sea(ShipX, hold - 1) = "s" Or Sea(ShipX, hold + 1) = "s"
                Sea(ShipX, hold) = "s"
            Next
        End If
        hold = 0
        Do
            ShipX = CInt(Rnd() * 19 + 1)
            ShipY = CInt(Rnd() * 19 + 1)
        Loop Until sea(ShipX, shipy) = "."
        bint = CInt(Rnd())
            Sea(ShipX, ShipY) = "q"
        If bint = 0 Then
            For c = 0 To lengthq
lapse:
                Do
                    hold = CInt(Rnd() * 19 + 1)
                    If hold = 20 Then
                        If Sea(ShipX, hold - 1) = "q" And Sea(ShipX, hold) = "." Then
                            Sea(ShipX, hold) = "q"
                            c = c + 1
                            GoTo lapse
                        Else
                            GoTo lapse

                        End If
                    End If
                    If Sea(ShipX, hold) = "s" Or Sea(ShipX, hold) = "t" Or Sea(hold, ShipY) = "v" Or Sea(hold, ShipY) = "q" Or Sea(hold, ShipY) = "u" Then
                        GoTo lapse
                    End If
                    check = check + 1
                    If check = 400 Then

                        GoTo retry
                    End If
                Loop Until Sea(ShipX, hold - 1) = "q" Or Sea(ShipX, hold + 1) = "q"
                Sea(ShipX, hold) = "q"
            Next
        Else
            For d = 0 To lengthq
plight:
                Do
                    hold = CInt(Rnd() * 8 + 1)
                    If hold = 20 Then
                        If Sea(hold - 1, ShipY) = "q" And Sea(hold, ShipY) = "." Then
                            Sea(hold, ShipY) = "q"
                            d = d + 1
                            GoTo plight
                        Else
                            GoTo plight
                        End If
                    End If
                    If Sea(hold, ShipY) <> "." Then
                        GoTo plight
                    End If
                    check = check + 1
                    If check = 400 Then

                        GoTo retry
                    End If
                Loop Until Sea(hold - 1, ShipY) = "q" Or Sea(hold + 1, ShipY) = "q"
                Sea(hold, ShipY) = "q"
            Next
        End If
        Do
            ShipX = CInt(Rnd() * 19 + 1)
            ShipY = CInt(Rnd() * 19 + 1)
        Loop Until Sea(ShipX, shipy) = "."
        Randomize()
        nint = CInt(Rnd())




        Sea(ShipX, ShipY) = "t"
        If nint = 0 Then
            For d = 0 To lengtht
Loops:

                Do
                    hold = CInt(Rnd() * 19 + 1)
                    If hold = 20 Then
                        If Sea(ShipX, hold - 1) = "t" And Sea(ShipX, hold) = "." Then
                            Sea(ShipX, hold) = "t"
                            d = d + 1

                            GoTo Loops
                        Else

                            GoTo Loops

                        End If

                    End If
                    If Sea(ShipX, hold) = "t" Or Sea(ShipX, hold) = "s" Or Sea(hold, ShipY) = "v" Or Sea(hold, ShipY) = "q" Or Sea(hold, ShipY) = "u" Then

                        GoTo Loops
                    End If
                    check = check + 1
                    If check = 400 Then
                        GoTo retry
                    End If
                Loop Until Sea(ShipX, hold - 1) = "t" Or Sea(shipX, hold + 1) = "t"
                Sea(ShipX, hold) = "t"

            Next
        Else
            For c = 0 To lengtht
Reps:
                Do
                    hold = CInt(Rnd() * 19 + 1)
                    If hold = 20 Then
                        If Sea(hold - 1, ShipY) = "t" And Sea(hold, ShipY) = "." Then
                            Sea(hold, ShipY) = "t"
                            c = c + 1
                            GoTo Reps
                        Else

                            GoTo Reps


                        End If
                    End If
                    If Sea(hold, ShipY) = "s" Or Sea(hold, ShipY) = "t" Or Sea(hold, ShipY) = "v" Or Sea(hold, ShipY) = "q" Or Sea(hold, ShipY) = "u" Then
                        GoTo Reps

                    End If
                    check = check + 1
                    If check = 400 Then
                        GoTo retry
                    End If
                Loop Until Sea(hold - 1, ShipY) = "t" Or Sea(hold + 1, ShipY) = "t"
                Sea(hold, ShipY) = "t"

            Next
        End If
        hold = 0
        Do
            ShipX = CInt(Rnd() * 19 + 1)
            ShipY = CInt(Rnd() * 19 + 1)
        Loop Until Sea(ShipX, shipY) = "."
        kint = CInt(Rnd())
        Sea(ShipX, ShipY) = "u"
        If kint = 0 Then

            For c = 0 To lengthb
consul:
                Do
                    hold = CInt(Rnd() * 19 + 1)
                    If hold = 20 Then
                        If Sea(hold - 1, ShipY) = "u" And Sea(hold, ShipY) = "." Then
                            Sea(hold, ShipY) = "u"
                            c = c + 1
                            GoTo consul
                        Else
                            GoTo consul
                        End If
                    End If
                    If Sea(hold, ShipY) <> "." Then
                        GoTo consul
                    End If
                Loop Until Sea(hold - 1, shipY) = "u" Or Sea(hold + 1, shipY) = "u"
                Sea(hold, shipY) = "u"
            Next

        Else
            For d = 0 To lengthb
Z:
                Do
                    hold = CInt(Rnd() * 19 + 1)
                    If hold = 20 Then
                        If Sea(ShipX, hold - 1) = "u" And Sea(ShipX, hold) = "." Then
                            Sea(ShipX, hold) = "u"
                            d = d + 1
                            GoTo Z
                        Else
                            GoTo Z

                        End If
                    End If
                    If Sea(ShipX, hold) <> "." Then
                        GoTo Z
                    End If

                Loop Until Sea(ShipX, hold - 1) = "u" Or Sea(ShipX, hold + 1) = "u"
                Sea(ShipX, hold) = "u"
            Next
        End If
        counts = 0
        counter = 0
        countq = 0
        countb = 0
        countk = 0

        For x = 1 To 20
            For y = 1 To 20
                Select Case Sea(x, y)
                    Case "s"
                        counts += 1
                    Case "t"
                        counter += 1
                    Case "q"
                        countq += 1
                    Case "u"
                        countb += 1
                    Case "v"
                        countk += 1
                End Select
            Next
        Next
    End Sub
End Module
