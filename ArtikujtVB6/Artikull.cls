VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Artikull"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Public IsNew As Boolean
Public id As Integer
Public Emri As String
Public Njesia As String
Public DataSkadences As Date
Public Cmimi As Double
Public mLloj As String
Public KaTvsh As Boolean
Public mTipi As String
Public Barkod As String






Public Function IsOnValidState() As Boolean
    IsOnValidState = True
    
    Dim title As String
    title = "Problem me artikullin"
    If Emri = "" Then
        MsgBox "Emri duhet plotesuar", vbOKOnly, title
        IsOnValidState = False
    ElseIf Njesia = "" Then
        MsgBox "Njesia duhet plotesuar", vbOKOnly, title
        IsOnValidState = False
    ElseIf mLloj = "" Then
        MsgBox "Lloj duhet plotesuar", vbOKOnly, title
        IsOnValidState = False
    ElseIf mTipi = "" Then
        MsgBox "Tipi duhet plotesuar", vbOKOnly, title
        IsOnValidState = False
    ElseIf Barkod = "" Then
        MsgBox "Barkod duhet plotesuar", vbOKOnly, title
        IsOnValidState = False
    End If
    
End Function



