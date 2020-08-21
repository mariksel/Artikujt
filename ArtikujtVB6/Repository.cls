VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Repository"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Dim aConnection As New ADODB.Connection
Dim aRecSet As New ADODB.Recordset



Private Sub Class_Initialize()
    aConnection.Open "Provider=sqloledb;Data Source=localhost;Initial Catalog=Expres;Trusted_Connection=yes;"
    
End Sub


Public Sub AddArtikull(artk As Artikull)
    Dim sql As String
    Dim dtS As String
    dtS = Format(artk.DataSkadences, "yyyy-MM-dd HH:mm:ss")
    
    sql = "INSERT INTO dbo.Artikujt(Emri, Njesia, DataSkadences, Cmimi, Lloj, KaTvsh, Tipi, Barkod) VALUES ("
    sql = sql & "N'" & artk.Emri & "',"
    sql = sql & "N'" & artk.Njesia & "',"
    sql = sql & "N'" & dtS & "',"
    sql = sql & artk.Cmimi & ","
    sql = sql & "N'" & artk.mLloj & "',"
    sql = sql & CStr(CInt(Abs(artk.KaTvsh))) & ","
    sql = sql & "N'" & artk.mTipi & "',"
    sql = sql & "N'" & artk.Barkod & "')"
    
    aConnection.Execute sql
    
End Sub

Public Sub UpdateArtikull(artk As Artikull)
    Dim sql As String
    Dim dtS As String
    dtS = Format(artk.DataSkadences, "yyyy-MM-dd HH:mm:ss")
    
    sql = "UPDATE dbo.Artikujt SET "
    sql = sql & "Emri = N'" & artk.Emri & "',"
    sql = sql & "Njesia = N'" & artk.Njesia & "',"
    sql = sql & "DataSkadences = N'" & dtS & "',"
    sql = sql & "Cmimi = N'" & artk.Cmimi & "',"
    sql = sql & "Lloj = N'" & artk.mLloj & "',"
    sql = sql & "KaTvsh = N'" & CStr(CInt(Abs(artk.KaTvsh))) & "',"
    sql = sql & "Tipi = N'" & artk.mTipi & "',"
    sql = sql & "Barkod = N'" & artk.Barkod & "'"
    sql = sql & "WHERE Id = " & artk.id
    
    aConnection.Execute sql
    
End Sub

Public Function GetArtikujt(Index As Integer) As Pagination
    Dim pgnt As New Pagination
    
    Dim pageSize As Integer
    pageSize = 10
    
    Dim offset As Integer
    offset = (Index - 1) * pageSize
    
    Dim query As String
    
    query = "SELECT * FROM dbo.Artikujt ORDER  BY Id DESC "
    query = query & "OFFSET  " & offset & "  ROWS FETCH NEXT " & pageSize & " ROWS ONLY"
    
    aRecSet.Open query, aConnection, adOpenKeyset
    
    Dim list As New Collection
    
    Dim i As Integer
    Dim artk As Artikull
    For i = 1 To aRecSet.RecordCount
        Set artk = New Artikull
        artk.id = aRecSet.Fields("Id")
        artk.Emri = aRecSet.Fields("Emri")
        artk.Njesia = aRecSet.Fields("Njesia")
        artk.DataSkadences = ParseDate(aRecSet.Fields("DataSkadences"))
        artk.Cmimi = aRecSet.Fields("Cmimi")
        artk.mLloj = aRecSet.Fields("Lloj")
        artk.KaTvsh = aRecSet.Fields("KaTvsh")
        artk.mTipi = aRecSet.Fields("Tipi")
        artk.Barkod = aRecSet.Fields("Barkod")
        
        list.Add artk, KerkoForm.Key(artk.id)
        
        
        aRecSet.MoveNext
        
    Next i
    
    aRecSet.Close
    
    Dim totalCount As Double
    totalCount = CountArtikujt
    
    
    
    pgnt.NumberOfPages = Ceil(totalCount / pageSize)
    
    pgnt.CurrentIndex = Index
    Set pgnt.Models = list
    
    Set GetArtikujt = pgnt

End Function

Public Function Ceil(num As Double) As Integer
    Dim ceilNum As Integer
    ceilNum = Int(num)
    If ceilNum <> num Then
        ceilNum = ceilNum + 1
    End If
    Ceil = ceilNum
End Function


Public Function CountArtikujt() As Integer
    
    Dim totalCount As Integer
    
    Dim query As String
    query = "SELECT COUNT(*) As TotalCount From dbo.Artikujt"

    aRecSet.Open query, aConnection, adOpenKeyset
    
    totalCount = aRecSet.Fields("TotalCount")
    
    aRecSet.Close
    
    CountArtikujt = totalCount
End Function

Public Sub DeleteArtikull(artk As Artikull)
    Dim sql As String
   
    sql = "DELETE FROM dbo.Artikujt "
    sql = sql & "WHERE Id = " & artk.id
    
    aConnection.Execute sql
End Sub

Public Function ParseDate(text As String) As Date
    Dim yearTxt As String, monthText As String, dayText As String
    Dim year As Integer, month As Integer, day As Integer
    yearTxt = Mid(text, 1, 4)
    monthText = Mid(text, 6, 2)
    dayText = Mid(text, 9, 2)
    
    year = CInt(yearTxt)
    month = CInt(monthText)
    day = CInt(dayText)
    
    ParseDate = DateSerial(year, month, day)
End Function





Public Sub Dispose()
    aConnection.Close
End Sub
